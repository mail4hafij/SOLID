using WCF.HelloWorld.Logic.Animal;

namespace WCF.HelloWorld.Logic
{
    public interface IHelloWorldLogicFactory
    {
        IAnimalLogic CreateStatusUpdateLogic(IHelloWorldUnitOfWork unitOfWork);
    }
}