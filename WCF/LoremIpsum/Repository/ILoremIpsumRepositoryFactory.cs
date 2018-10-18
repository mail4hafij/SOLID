using WCF.LoremIpsum.Repository.Tiger;

namespace WCF.LoremIpsum.Repository
{
    public interface ILoremIpsumRepositoryFactory
    {
        ITigerRepository CreateTigerRepository(ILoremIpsumUnitOfWork unitOfWork);
    }
}