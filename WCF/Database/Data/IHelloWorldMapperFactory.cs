using WCF.Database.Data.Mapper;
using WCF.LIB;

namespace WCF.Database.Data
{
    public interface IHelloWorldMapperFactory
    {
        ICatMapper CreateCatMapper(IHelloWorldUnitOfWork unitOfWork);
        IDogMapper CreateDogMapper(IHelloWorldUnitOfWork unitOfWork);
    }
}
