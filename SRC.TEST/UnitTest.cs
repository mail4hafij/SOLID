using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRC.TEST.Ioc;

namespace SRC.TEST
{
    public class UnitTest
    {
        public TestContainer _testContainer = new TestContainer();

        [TestInitialize]
        public void TestInit()
        {
            // initialize database content with test data.
        }

        [TestCleanup]
        public void TestClean()
        {
            // empty database.
        }
    }
}
