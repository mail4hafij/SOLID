using API.Contracts;

namespace SRC.LIB
{
    public abstract class ServiceBase
    {
        private readonly IHandlerCaller _handlerCaller;

        protected ServiceBase(IHandlerCaller handlerCaller)
        {
            _handlerCaller = handlerCaller;
        }

        protected TResp Process<TReq, TResp>(TReq req) where TResp : Resp, new() where TReq : Req, new()
        {
            return _handlerCaller.Process<TReq, TResp>(req);
        }

    }
}
