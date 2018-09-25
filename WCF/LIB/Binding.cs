using Ninject.Modules;
using Ninject.Extensions.Factory;
using WCF.Handler.Cat;
using WCF.Handler.Dog;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;

namespace WCF.LIB
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<RequestHandler<GetCatReq, GetCatResp>>().To<GetCatHandler>();
            Bind<RequestHandler<GetDogReq, GetDogResp>>().To<GetDogHandler>();
            Bind<IResponseFactory>().To<ResponseFactory>();
            Bind<IRequestHandlerFactory>().ToFactory();
            Bind<IHandlerCaller>().To<HandlerCaller>();
        }
    }
}
