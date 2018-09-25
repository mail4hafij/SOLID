using API.Contracts;

namespace WCF.LIB
{
    public interface IRequestHandlerFactory
    {
        RequestHandler<TReq, TResp> Create<TReq, TResp>() where TReq : Req, new() where TResp : Resp, new();
    }
}