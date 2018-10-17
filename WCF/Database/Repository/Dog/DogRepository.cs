using System;
using System.Collections.Generic;
using System.Linq;

namespace WCF.Database.Repository.Dog
{
    public class DogRepository : HelloWorldBaseRepository, IDogRepository
    {
        public DogRepository(IHelloWorldUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public List<WCF.Database.Data.Model.Dog> LoadAll()
        {
            return _unitOfWork.Context.Dogs.ToList<Data.Model.Dog>();
        }
    }
}
