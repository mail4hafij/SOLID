using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using Ninject;
using Ninject.Extensions.Factory;
using WCF.HelloWorld;
using WCF.HelloWorld.Data;
using WCF.HelloWorld.Data.Mapper;
using WCF.HelloWorld.Logic;
using WCF.HelloWorld.Repository;
using WCF.HelloWorld.Repository.Cat;
using WCF.HelloWorld.Repository.Dog;
using WCF.Handler.Cat;
using WCF.Handler.Dog;
using WCF.LIB;
using WCF.LoremIpsum;
using WCF.LoremIpsum.Logic;
using WCF.LoremIpsum.Repository;
using WCF.LoremIpsum.Data;
using WCF.LoremIpsum.Repository.Tiger;
using WCF.LoremIpsum.Data.Mapper;
using API.Contracts.Tiger.Messaging;

namespace WCF.Ioc
{
    public class Container
    {
        public IKernel _kernel;

        public Container()
        {
            _kernel = new StandardKernel();


            BindRepositories();
            BindMappers();
            BindLogic();
            BindFactories();
            BindHandlers();


            // Static config
            _kernel.Bind<IStaticConfig>().To<StaticConfig>();
            // UnitOfWorkFactory
            _kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            // Lib
            _kernel.Bind<IResponseFactory>().To<ResponseFactory>();
            _kernel.Bind<IHandlerCaller>().To<HandlerCaller>();
            _kernel.Bind<IRequestHandlerFactory>().ToFactory();
        }

        private void BindRepositories()
        {
            // (helloworld)
            _kernel.Bind<ICatRepository>().To<CatRepository>();
            _kernel.Bind<IDogRepository>().To<DogRepository>();

            // (loremipsum)
            _kernel.Bind<ITigerRepository>().To<TigerRepository>();
        }

        private void BindMappers()
        {
            // (helloworld)
            _kernel.Bind<ICatMapper>().To<CatMapper>();
            _kernel.Bind<IDogMapper>().To<DogMapper>();

            // (loremipsum)
            _kernel.Bind<ITigerMapper>().To<TigerMapper>();
        }

        private void BindLogic()
        {

        }

        private void BindFactories()
        {
            // Database factories (helloworld)
            _kernel.Bind<IHelloWorldDatabaseService>().To<HelloWorldDatabaseService>();
            _kernel.Bind<IHelloWorldLogicFactory>().ToFactory();
            _kernel.Bind<IHelloWorldRepositoryFactory>().ToFactory();
            _kernel.Bind<IHelloWorldMapperFactory>().ToFactory();

            // Database factories (loremipsum)
            _kernel.Bind<ILoremIpsumDatabaseService>().To<LoremIpsumDatabaseService>();
            _kernel.Bind<ILoremIpsumLogicFactory>().ToFactory();
            _kernel.Bind<ILoremIpsumRepositoryFactory>().ToFactory();
            _kernel.Bind<ILoremIpsumMapperFactory>().ToFactory();
        }

        private void BindHandlers()
        {
            // (helloworld)
            _kernel.Bind<RequestHandler<GetCatReq, GetCatResp>>().To<GetCatHandler>();
            _kernel.Bind<RequestHandler<GetDogReq, GetDogResp>>().To<GetDogHandler>();

            // (loremipsum)
            _kernel.Bind<RequestHandler<GetTigerReq, GetTigerResp>>().To<GetTigerHandler>();
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
