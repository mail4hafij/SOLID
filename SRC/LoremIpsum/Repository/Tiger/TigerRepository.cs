using System.Collections.Generic;
using System.Linq;
using SRC.LoremIpsum.Data.Model;

namespace SRC.LoremIpsum.Repository.Tiger
{
    public class TigerRepository : LoremIpsumBaseRepository, ITigerRepository
    {
        public TigerRepository(ILoremIpsumUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<SRC.LoremIpsum.Data.Model.Tiger> LoadAll()
        {
            return _unitOfWork.Context.Tigers.ToList<Data.Model.Tiger>();
        }

        public void Add(SRC.LoremIpsum.Data.Model.Tiger tiger)
        {
            _unitOfWork.Context.Tigers.Add(tiger);
        }
    }
}
