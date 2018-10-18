using System.Collections.Generic;

namespace WCF.LoremIpsum.Repository.Tiger
{
    public interface ITigerRepository
    {
        List<WCF.LoremIpsum.Data.Model.Tiger> LoadAll();
    }
}