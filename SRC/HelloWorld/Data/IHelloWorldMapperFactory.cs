using SRC.HelloWorld.Data.Mapper;


namespace SRC.HelloWorld.Data
{
    public interface IHelloWorldMapperFactory
    {
        ICatMapper CreateCatMapper(IHelloWorldUnitOfWork unitOfWork);
        IDogMapper CreateDogMapper(IHelloWorldUnitOfWork unitOfWork);
    }
}
