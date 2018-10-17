using WCF.LIB;
using WCF.Database;

namespace WCF
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDatabaseService _databaseService;
        
        public UnitOfWorkFactory(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public IHelloWorldUnitOfWork CreateAndBeginTransactionForHelloWorld(bool useChangeTracking = true)
        {
            var unitOfWork = new HelloWorldUnitOfWork(_databaseService);
            unitOfWork.Begin();
            unitOfWork.Context.Configuration.AutoDetectChangesEnabled = useChangeTracking;
            return unitOfWork;
        }

    }
}
