using WCF.HelloWorld.Data.Mapper;


namespace WCF.HelloWorld.Data
{
    public interface IHelloWorldMapperFactory
    {
        ICatMapper CreateCatMapper(IHelloWorldUnitOfWork unitOfWork);
        IDogMapper CreateDogMapper(IHelloWorldUnitOfWork unitOfWork);
    }
}
