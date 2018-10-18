using WCF.HelloWorld;
using WCF.LoremIpsum;

namespace WCF
{
    public interface IUnitOfWorkFactory
    {
        IHelloWorldUnitOfWork CreateAndBeginTransactionForHelloWorld(bool useChangeTracking = true);

        ILoremIpsumUnitOfWork CreateAndBeginTransactionForLoremIpsum(bool useChangeTracking = true);

    }
}
