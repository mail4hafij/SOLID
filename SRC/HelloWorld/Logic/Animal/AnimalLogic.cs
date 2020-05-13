
using SRC.HelloWorld.Repository;

namespace SRC.HelloWorld.Logic.Animal
{
    public class AnimalLogic : HelloWorldBaseLogic, IAnimalLogic
    {
        private readonly IHelloWorldRepositoryFactory _repositoryFactory;

        public AnimalLogic(IHelloWorldUnitOfWork unitOfWork, IHelloWorldRepositoryFactory reporepositoryFactory) : base(unitOfWork)
        {
            _repositoryFactory = reporepositoryFactory;
        }

        public void AddAnimals(string catColor, string dogColor)
        {
            var catRepo = _repositoryFactory.CreateCatRepository(_unitOfWork);
            var dogRepo = _repositoryFactory.CreateDogRepository(_unitOfWork);

            catRepo.Add(new Data.Model.Cat() { Color = catColor });
            dogRepo.Add(new Data.Model.Dog() { Color = dogColor });
        }
    }
}
