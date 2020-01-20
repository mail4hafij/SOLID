using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRC.HelloWorld.Repository;
using SRC.LoremIpsum.Repository;
using SRC.TEST.Ioc;

namespace SRC.TEST
{
    public class BaseTest
    {
        public TestContainer _testContainer = new TestContainer();
        public TestDataBase _testDataBase = new TestDataBase();

        private UnitOfWorkFactory _unitOfWorkFactory;
        private IHelloWorldRepositoryFactory _helloWorldRepositoryFactory;
        private ILoremIpsumRepositoryFactory _loremIpsumRepositoryFactory;
        
        public BaseTest()
        {
            _unitOfWorkFactory = _testContainer.Get<UnitOfWorkFactory>();
            _helloWorldRepositoryFactory = _testContainer.Get<IHelloWorldRepositoryFactory>();
            _loremIpsumRepositoryFactory = _testContainer.Get<ILoremIpsumRepositoryFactory>();
        }

        [TestInitialize]
        public void TestInit()
        {
            // initialize helloWorld database content with test data.
            using (var unitOfWork = _unitOfWorkFactory.CreateAndBeginTransactionForHelloWorld(false))
            {
                // empty
                unitOfWork.Context.Database.ExecuteSqlCommand("TRUNCATE TABLE Cats");
                unitOfWork.Context.Database.ExecuteSqlCommand("TRUNCATE TABLE Dogs");

                // add
                var catRepo = _helloWorldRepositoryFactory.CreateCatRepository(unitOfWork);
                catRepo.Add(_testDataBase.Cats.White);
                var dogRepo = _helloWorldRepositoryFactory.CreateDogRepository(unitOfWork);
                dogRepo.Add(_testDataBase.Dogs.Black);

                unitOfWork.Commit();
            }
            

            // intialize loremipsum database content with test data.
            using (var unitOfWork = _unitOfWorkFactory.CreateAndBeginTransactionForLoremIpsum(false))
            {
                // empty
                unitOfWork.Context.Database.ExecuteSqlCommand("TRUNCATE TABLE Tigers");

                // add
                var tigerRepo = _loremIpsumRepositoryFactory.CreateTigerRepository(unitOfWork);
                tigerRepo.Add(_testDataBase.Tigers.Yellow);

                unitOfWork.Commit();
            }



        }

        [TestCleanup]
        public void TestClean()
        {
            // empty database.
        }
    }
}
