using API.Contracts;
using System;

namespace SRC.LIB
{
    public class HandlerCaller : IHandlerCaller
    {
        private readonly IRequestHandlerFactory _requestHandlerFactory;
        private readonly IResponseFactory _responseFactory;
        
        public HandlerCaller(
            IRequestHandlerFactory requestHandlerFactory,
            IResponseFactory responseFactory)
        {
            _requestHandlerFactory = requestHandlerFactory;
            _responseFactory = responseFactory;
        }

        public TResp Process<TReq, TResp>(TReq req) where TResp : Resp, new() where TReq : Req, new()
        {
            var name = typeof(TReq).Name;
            if (name.Length > 3) name = name.Substring(0, name.Length - 3);

            TResp response;

            try
            {
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

                response = requestHandler.Process(req);
            }
            catch (Exception exc)
            {
                //Create a default exception error response
                response = _responseFactory.GetExceptionErrorResp<TResp>(exc, exc.Message);
            }

            return response;
        }
    }
}
