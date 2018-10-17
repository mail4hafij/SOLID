using System.Collections.Generic;

namespace WCF.Database.Repository.Dog
{
    public interface IDogRepository
    {
        List<WCF.Database.Data.Model.Dog> LoadAll();
    }
}
