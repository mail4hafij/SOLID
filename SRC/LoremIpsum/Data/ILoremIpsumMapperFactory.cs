
using SRC.LoremIpsum.Data.Mapper;

namespace SRC.LoremIpsum.Data
{
    public interface ILoremIpsumMapperFactory
    {
        ITigerMapper CreateTigerMapper(ILoremIpsumUnitOfWork unitOfWork);
    }
}
