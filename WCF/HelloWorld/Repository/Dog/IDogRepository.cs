using System.Collections.Generic;

namespace WCF.HelloWorld.Repository.Dog
{
    public interface IDogRepository
    {
        List<WCF.HelloWorld.Data.Model.Dog> LoadAll();
    }
}
