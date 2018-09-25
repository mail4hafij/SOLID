using API.Contracts;

namespace WCF.LIB
{
    public interface IHandlerCaller
    {
        TResp Process<TReq, TResp>(TReq req) where TResp : Resp, new() where TReq : Req, new();
    }
}
