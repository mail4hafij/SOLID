using SRC.LIB;
using SRC.HelloWorld;
using SRC.LoremIpsum;

namespace SRC
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IHelloWorldDatabaseService _helloWorldDatabaseService;
        private readonly ILoremIpsumDatabaseService _loremIpsumDatabaseService;

        public UnitOfWorkFactory(IHelloWorldDatabaseService _helloWorld, ILoremIpsumDatabaseService _loremIpsum)
        {
            _helloWorldDatabaseService = _helloWorld;
            _loremIpsumDatabaseService = _loremIpsum;
        }

        public IHelloWorldUnitOfWork CreateAndBeginTransactionForHelloWorld(bool useChangeTracking = true)
        {
            var unitOfWork = new HelloWorldUnitOfWork(_helloWorldDatabaseService);
            unitOfWork.Begin();
            unitOfWork.Context.Configuration.AutoDetectChangesEnabled = useChangeTracking;
            return unitOfWork;
        }

        
        public ILoremIpsumUnitOfWork CreateAndBeginTransactionForLoremIpsum(bool useChangeTracking = true)
        {
            var unitOfWork = new LoremIpsumUnitOfWork(_loremIpsumDatabaseService);
            unitOfWork.Begin();
            unitOfWork.Context.Configuration.AutoDetectChangesEnabled = useChangeTracking;
            return unitOfWork;
        }
        
    }
}
