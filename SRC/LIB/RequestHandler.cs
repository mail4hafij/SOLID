using API.Contracts;
using System;
using System.Linq;
using System.Reflection;


namespace SRC.LIB
{
    public abstract class RequestHandler<TReq, TResp> where TReq : Req, new() where TResp : Resp, new()
    {
        private readonly IResponseFactory _responseFactory;
        
        protected RequestHandler(IResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
        }

        protected RequestHandler()
        {

        }

        public abstract TResp Process(TReq req);

        protected TResp GetSuccessResp(object setProperties = null)
        {
            var response = _responseFactory.GetSuccessResp<TResp>();
            var responseProperties = response.GetType().GetProperties();

            setProperties?
                         .GetType()
                         .GetProperties()
                         .Where(x => x.CanRead &&
                                    responseProperties.Any(y => y.CanWrite &&
                                                                y.Name == x.Name &&
                                                                y.PropertyType
                                                                 .IsAssignableFrom(x.PropertyType)))
                         .ForEach(propertyToGet =>
                         {
                             response.GetType()
                                 .GetProperty(propertyToGet.Name, BindingFlags.Public | BindingFlags.Instance)
                                 ?.SetValue(response, propertyToGet.GetValue(setProperties), null);
                         });

            return response;
        }

        protected TResp GetFailureResp(string text = null)
        {
            var resp = _responseFactory.GetFailureResp<TResp>();
            if (text != null)
            {
                resp.ExceptionError = new ExceptionError()
                {
                    Text = text
                };
            }
            return resp;
        }

        protected TResp GetExceptionErrorResp(Exception exception, string text = null)
        {
            return _responseFactory.GetExceptionErrorResp<TResp>(exception, text);
        }
    }
}
