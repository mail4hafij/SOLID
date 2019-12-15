using SRC.LoremIpsum.Repository.Tiger;

namespace SRC.LoremIpsum.Repository
{
    public interface ILoremIpsumRepositoryFactory
    {
        ITigerRepository CreateTigerRepository(ILoremIpsumUnitOfWork unitOfWork);
    }
}