using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using Ninject;
using Ninject.Extensions.Factory;
using WCF.Handler.Cat;
using WCF.Handler.Dog;

namespace WCF.LIB
{
    public class Container
    {
        public IKernel _kernel;

        public Container()
        {
            _kernel = new StandardKernel();

            // Do all the bindings here.
            _kernel.Bind<RequestHandler<GetCatReq, GetCatResp>>().To<GetCatHandler>();
            _kernel.Bind<RequestHandler<GetDogReq, GetDogResp>>().To<GetDogHandler>();
            _kernel.Bind<IResponseFactory>().To<ResponseFactory>();
            _kernel.Bind<IRequestHandlerFactory>().ToFactory();
            _kernel.Bind<IHandlerCaller>().To<HandlerCaller>();
        }

        public T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public void Rebind<T>(T obj)
        {
            _kernel.Rebind<T>().ToConstant(obj).InSingletonScope();
        }
    }
}
