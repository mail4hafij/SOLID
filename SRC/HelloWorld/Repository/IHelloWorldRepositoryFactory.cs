using SRC.HelloWorld.Repository.Cat;
using SRC.HelloWorld.Repository.Dog;

namespace SRC.HelloWorld.Repository
{
    public interface IHelloWorldRepositoryFactory
    {
        // NOTE: the IUnitOfWork parameter *must* be named 'unitOfWork', otherwise the IoC factory creation won't work
        // see https://github.com/ninject/Ninject.Extensions.Factory/wiki/Factory-interface
        ICatRepository CreateCatRepository(IHelloWorldUnitOfWork unitOfWork);
        IDogRepository CreateDogRepository(IHelloWorldUnitOfWork unitOfWork);
    }
}