using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Contracts.Cat.Messaging;

namespace SRC.TEST.InegrationTest
{
    [TestClass]
    public class BasicTest : UnitTest
    {
        [TestMethod]
        public void BasicReadFromDatabaseTest()
        {
            var animalService = _testContainer.Get<API.IAnimalService>();
            var cat = animalService.GetCat(new GetCatReq());
            Assert.IsTrue(cat.Success);
        }
    }
}
