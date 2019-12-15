using Ninject.Modules;
using Ninject.Extensions.Factory;
using SRC.Handler.Cat;
using SRC.Handler.Dog;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using SRC.LIB;

namespace SRC.Ioc
{
    /// <summary>
    /// Using NijectModule 
    /// The class name can be anything. 
    /// Just need to override the Load function and 
    /// bind all the classes.
    /// </summary>
    public class Module : NinjectModule
    {
        public override void Load()
        {
            // Do all the bindings here.
            /*
            Bind<RequestHandler<GetCatReq, GetCatResp>>().To<GetCatHandler>();
            Bind<RequestHandler<GetDogReq, GetDogResp>>().To<GetDogHandler>();
            Bind<IResponseFactory>().To<ResponseFactory>();
            Bind<IRequestHandlerFactory>().ToFactory();
            Bind<IHandlerCaller>().To<HandlerCaller>();
            */
        }
    }
}
