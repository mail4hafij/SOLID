using System;
using System.Collections.Generic;
using System.Linq;

namespace SRC.HelloWorld.Repository.Dog
{
    public class DogRepository : HelloWorldBaseRepository, IDogRepository
    {
        public DogRepository(IHelloWorldUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public List<SRC.HelloWorld.Data.Model.Dog> LoadAll()
        {
            return _unitOfWork.Context.Dogs.OrderByDescending(d => d.DogId).ToList<Data.Model.Dog>();
        }

        public void Add(SRC.HelloWorld.Data.Model.Dog dog)
        {
            _unitOfWork.Context.Dogs.Add(dog);
        }
    }
}
