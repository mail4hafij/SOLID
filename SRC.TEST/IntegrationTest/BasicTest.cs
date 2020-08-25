using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using API.Contracts.Tiger.Messaging;


namespace SRC.TEST.IntegrationTest
{
    [TestClass]
    public class BasicTest : BaseTest
    {
        [TestMethod]
        public void BasicReadFromDatabaseTest()
        {
            var animalService = _testContainer.Get<API.IAnimalService>();
            
            var respCat = animalService.GetCat(new GetCatReq());
            Assert.IsTrue(respCat.Success);
            Assert.AreEqual("White", respCat.Cat.Color);

            var respDog = animalService.GetDog(new GetDogReq());
            Assert.IsTrue(respDog.Success);
            Assert.AreEqual("Black", respDog.Dog.Color);

            var respTiger = animalService.GetTiger(new GetTigerReq());
            Assert.IsTrue(respTiger.Success);
            Assert.AreEqual("Yellow", respTiger.Tiger.Color);
        }
    }
}
