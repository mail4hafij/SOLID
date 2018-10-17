using System.Collections.Generic;

namespace WCF.Database.Repository.Cat
{
    public interface ICatRepository
    {
        List<WCF.Database.Data.Model.Cat> LoadAll();
    }
}