using System.Collections.Generic;

namespace WCF.HelloWorld.Repository.Cat
{
    public interface ICatRepository
    {
        List<WCF.HelloWorld.Data.Model.Cat> LoadAll();
    }
}