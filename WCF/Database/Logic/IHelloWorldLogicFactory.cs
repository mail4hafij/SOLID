using WCF.Database.Logic.Animal;

namespace WCF.Database.Logic
{
    public interface IHelloWorldLogicFactory
    {
        IAnimalLogic CreateStatusUpdateLogic(IHelloWorldUnitOfWork unitOfWork);
    }
}