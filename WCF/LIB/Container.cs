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
        protected IKernel Kernel;

        public Container()
        {
            Kernel = new StandardKernel();

            Kernel.Bind<RequestHandler<GetCatReq, GetCatResp>>().To<GetCatHandler>();
            Kernel.Bind<RequestHandler<GetDogReq, GetDogResp>>().To<GetDogHandler>();
            Kernel.Bind<IResponseFactory>().To<ResponseFactory>();
            Kernel.Bind<IRequestHandlerFactory>().ToFactory();
            Kernel.Bind<IHandlerCaller>().To<HandlerCaller>();
        }

        public T Get<T>()
        {
            return Kernel.Get<T>();
        }

        public void Rebind<T>(T obj)
        {
            Kernel.Rebind<T>().ToConstant(obj).InSingletonScope();
        }
    }
}
