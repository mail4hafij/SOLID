using System.Collections.Generic;
using System.Linq;
using WCF.LIB;

namespace WCF.LoremIpsum.Repository.Tiger
{
    public class TigerRepository : LoremIpsumBaseRepository, ITigerRepository
    {
        public TigerRepository(ILoremIpsumUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<WCF.LoremIpsum.Data.Model.Tiger> LoadAll()
        {
            return _unitOfWork.Context.Tigers.ToList<Data.Model.Tiger>();
        }
    }
}
