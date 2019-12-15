using System;
using API.Contracts;

namespace SRC.LIB
{
    public class ResponseFactory : IResponseFactory
    {
        public TResp GetSuccessResp<TResp>() where TResp : Resp, new()
        {
            return new TResp()
            {
                Success = true
            };
        }

        public TResp GetFailureResp<TResp>() where TResp : Resp, new()
        {
            return new TResp()
            {
                Success = false
            };
        }

        public TResp GetExceptionErrorResp<TResp>(Exception exception, string text = null) where TResp : Resp, new()
        {
            return new TResp()
            {
                Success = false,
                ExceptionError = new ExceptionError()
                {
                    Text = text,
                    StackTrace = exception.Message
                }
            };
        }

    }
}