using API.Contracts;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace SRC
{
    public class HandlerCaller : IHandlerCaller
    {
        public TResp Process<TReq, TResp>(TReq req) where TResp : Resp, new() where TReq : Req, new()
        {
            var name = typeof(TReq).Name;
            if (name.Length > 3) name = name.Substring(0, name.Length - 3);

            var stopwatch = Stopwatch.StartNew();
            TResp response;

            try
            {
                //Validate security token
                if (req != null && !_securityTokenService.Validate(req.SecurityToken))
                {
                    throw new Exception("Not valid security token");
                }

                //Försök att hämta en requesthandler för
                //kombinationen TReq/TResp
                RequestHandler<TReq, TResp> requestHandler = null;
                try
                {
                    requestHandler = _requestHandlerFactory.Create<TReq, TResp>();
                }
                catch (Exception exc)
                {
                    var message = $"Could not create a request handler for {typeof(TReq).FullName}/{typeof(TResp).FullName}. Please register the request handler in the IoC container.";
                    throw new Exception(message, exc);
                }

                //Sätt identity
                requestHandler.Identity = Cache.GetOrFetchFromDataStore<IIdentity>(req?.Identity?.CacheKey() ?? "IdentityCacheKey=>null", TimeSpan.FromDays(1),
                () =>
                {
                    using (var unitOfWork = _unitOfWorkFactory.CreateAndBeginTransaction())
                    {
                        var userFactory = _repositoryFactory.CreateUserRepository(unitOfWork);
                        return userFactory.GetIdentity(req?.Identity?.UserId ?? 0, req?.Identity?.ImpersonatorUserId);
                    }
                });


                //Validera att anroparen har tillåtelse att utföra anropet
                try
                {
                    requestHandler.Authorize(req);
                }
                catch (AuthorizationException ex)
                {
                    return _responseFactory.GetAuthorizationErrorResp<TResp>(ex);
                }

                //Utför själva anropet
                response = requestHandler.Process(req);
            }
            catch (Exception exc)
            {
                _log.Error($"Error when calling Boris. UserId: {req?.Identity?.UserId.ToString() ?? "null"}, ImpersonatorUserId: {req?.Identity?.ImpersonatorUserId?.ToString() ?? "null"}, Roles: {string.Join(", ", req?.Identity?.Roles ?? new string[0]) }", exc);

                //Skapa ett default exception error response
                response = _responseFactory.GetExceptionErrorResp<TResp>(exc, exc.Message);
            }

            LogJson(response, name);

            //Logga alltid json för alla fel
            if (!response.Success)
            {
                var log = GetJsonLog("Boris.Json." + name);
                if (log.IsErrorEnabled)
                {
                    var msg = GetJson(req) + "\n" + GetJson(response);
                    log.Error(msg);
                }
            }

            var ms = stopwatch.ElapsedMilliseconds;
            _performanceLog.Info($"{name}|{ms}");

            return response;
        }

        private bool LogJson(object obj, string name)
        {
            try
            {
                if (obj == null) return false;
                var typeName = obj.GetType().Name;
                var log1 = GetJsonLog("Boris.Json." + typeName);
                var log2 = GetJsonLog("Boris.Json." + name);
                if (log1.IsDebugEnabled || log2.IsDebugEnabled)
                {
                    var log = log1.IsDebugEnabled ? log1 : log2;
                    log.Debug(GetJson(obj));
                    return true;
                }
            }
            catch
            {
                // ignored
            }
            return false;
        }

        private string GetJson(object obj)
        {
            var json = _debugJsonSerializer.Serialize(obj);
            var length = json?.Length;
            if (json != null && json.Length > _maxJsonLength) json = json.Substring(0, _maxJsonLength) + $"... truncated after {_maxJsonLength}({length})";
            return json;
        }

        private static ILog GetJsonLog(string name)
        {
            if (_jsonLogs.ContainsKey(name)) return _jsonLogs[name];
            var log = LogManager.GetLogger(name);
            if (!_jsonLogs.ContainsKey(name)) _jsonLogs[name] = log;
            return log;
        }

    }
}
