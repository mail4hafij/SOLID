using SRC.HelloWorld;
using SRC.LoremIpsum;

namespace SRC
{
    public interface IUnitOfWorkFactory
    {
        IHelloWorldUnitOfWork CreateAndBeginTransactionForHelloWorld(bool useChangeTracking = true);

        ILoremIpsumUnitOfWork CreateAndBeginTransactionForLoremIpsum(bool useChangeTracking = true);

    }
}
