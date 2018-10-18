using System.Collections.Generic;
using System.Linq;
using WCF.LIB;

namespace WCF.HelloWorld.Repository.Cat
{
    public class CatRepository : HelloWorldBaseRepository, ICatRepository
    {
        public CatRepository(IHelloWorldUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<WCF.HelloWorld.Data.Model.Cat> LoadAll()
        {
            return _unitOfWork.Context.Cats.ToList<Data.Model.Cat>();
        }
    }
}
