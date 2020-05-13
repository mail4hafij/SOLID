using API.Contracts.Animals.Messaging;
using SRC.HelloWorld.Logic;
using SRC.LIB;

namespace SRC.Handler.Animal
{
    public class AddAnimalsHandler : RequestHandler<AddAnimalsReq, AddAnimalsResp>
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IHelloWorldLogicFactory _logicFactory;
        
        public AddAnimalsHandler(IUnitOfWorkFactory unitOfWorkFactory, IHelloWorldLogicFactory logicFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logicFactory = logicFactory;
        }
        public override AddAnimalsResp Process(AddAnimalsReq req)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateAndBeginTransactionForHelloWorld(false))
            {
                var animalLogic = _logicFactory.CreateAnimalLogic(unitOfWork);
                animalLogic.AddAnimals(req.CatColor, req.DogColor);

                unitOfWork.Commit();
                return new AddAnimalsResp();
            }
        }
    }
}