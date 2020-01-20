using System.Collections.Generic;

namespace SRC.LoremIpsum.Repository.Tiger
{
    public interface ITigerRepository
    {
        List<SRC.LoremIpsum.Data.Model.Tiger> LoadAll();
        void Add(SRC.LoremIpsum.Data.Model.Tiger tiger);

    }
}