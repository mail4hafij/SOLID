using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Contracts.Animals.Messaging;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;

namespace SRC.TEST.IntegrationTest
{
    [TestClass]
    public class AnimalLogicTest : BaseTest
    {
        [TestMethod]
        public void AddAnimals()
        {
            var animalService = _testContainer.Get<API.IAnimalService>();
            var resp = animalService.AddAnimals(new AddAnimalsReq() { CatColor = "white", DogColor = "black" });
            Assert.IsTrue(resp.Success);

            var respCat = animalService.GetCat(new GetCatReq());
            Assert.IsTrue(respCat.Success);
            Assert.AreEqual("white", respCat.Cat.Color);

            var respDog = animalService.GetDog(new GetDogReq());
            Assert.IsTrue(respDog.Success);
            Assert.AreEqual("black", respDog.Dog.Color);
        }
    }
}
