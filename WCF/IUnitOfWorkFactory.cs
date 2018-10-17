using WCF.Database;

namespace WCF
{
    public interface IUnitOfWorkFactory
    {
        IHelloWorldUnitOfWork CreateAndBeginTransactionForHelloWorld(bool useChangeTracking = true);
    }
}
