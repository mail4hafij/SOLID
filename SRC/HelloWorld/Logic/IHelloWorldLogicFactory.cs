using SRC.HelloWorld.Logic.Animal;

namespace SRC.HelloWorld.Logic
{
    public interface IHelloWorldLogicFactory
    {
        IAnimalLogic CreateAnimalLogic(IHelloWorldUnitOfWork unitOfWork);
    }
}