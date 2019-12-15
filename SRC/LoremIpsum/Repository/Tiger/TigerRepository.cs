using System.Collections.Generic;
using System.Linq;
using SRC.LIB;

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
    }
}
