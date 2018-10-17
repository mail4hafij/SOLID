
namespace WCF.Database.Logic.Animal
{
    public class AnimalLogic : BaseLogic, IAnimalLogic
    {
        public AnimalLogic(IHelloWorldUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
