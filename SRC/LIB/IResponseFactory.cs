using API.Contracts;
using System;

namespace SRC.LIB
{
    public interface IResponseFactory
    {
        TResp GetSuccessResp<TResp>() where TResp : Resp, new();
        TResp GetFailureResp<TResp>() where TResp : Resp, new();
        TResp GetExceptionErrorResp<TResp>(Exception exception, string text = null) where TResp : Resp, new();
    }
}