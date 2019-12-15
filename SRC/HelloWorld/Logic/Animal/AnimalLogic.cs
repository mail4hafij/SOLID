
namespace SRC.HelloWorld.Logic.Animal
{
    public class AnimalLogic : HelloWorldBaseLogic, IAnimalLogic
    {
        public AnimalLogic(IHelloWorldUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
