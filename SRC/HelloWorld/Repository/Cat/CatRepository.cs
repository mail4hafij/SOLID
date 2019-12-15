using System.Collections.Generic;
using System.Linq;
using SRC.LIB;

namespace SRC.HelloWorld.Repository.Cat
{
    public class CatRepository : HelloWorldBaseRepository, ICatRepository
    {
        public CatRepository(IHelloWorldUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<SRC.HelloWorld.Data.Model.Cat> LoadAll()
        {
            return _unitOfWork.Context.Cats.ToList<Data.Model.Cat>();
        }
    }
}
