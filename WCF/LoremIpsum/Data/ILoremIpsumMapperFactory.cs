
using WCF.LoremIpsum.Data.Mapper;

namespace WCF.LoremIpsum.Data
{
    public interface ILoremIpsumMapperFactory
    {
        ITigerMapper CreateTigerMapper(ILoremIpsumUnitOfWork unitOfWork);
    }
}
