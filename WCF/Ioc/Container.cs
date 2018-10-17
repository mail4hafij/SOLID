using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using Ninject;
using Ninject.Extensions.Factory;
using WCF.Database;
using WCF.Database.Data;
using WCF.Database.Data.Mapper;
using WCF.Database.Logic;
using WCF.Database.Repository;
using WCF.Database.Repository.Cat;
using WCF.Database.Repository.Dog;
using WCF.Handler.Cat;
using WCF.Handler.Dog;
using WCF.LIB;


namespace WCF.Ioc
{
    public class Container
    {
        public IKernel _kernel;

        public Container()
        {
            _kernel = new StandardKernel();

            // Repositories
            _kernel.Bind<ICatRepository>().To<CatRepository>();
            _kernel.Bind<IDogRepository>().To<DogRepository>();

            // Mappers
            _kernel.Bind<ICatMapper>().To<CatMapper>();
            _kernel.Bind<IDogMapper>().To<DogMapper>();

            // Database factories
            _kernel.Bind<IStaticConfig>().To<StaticConfig>();
            _kernel.Bind<IDatabaseService>().To<HelloWorldDatabaseService>();
            _kernel.Bind<IHelloWorldLogicFactory>().ToFactory();
            _kernel.Bind<IHelloWorldRepositoryFactory>().ToFactory();
            _kernel.Bind<IHelloWorldMapperFactory>().ToFactory();
            _kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();


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
