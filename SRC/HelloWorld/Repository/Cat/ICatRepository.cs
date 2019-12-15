using System.Collections.Generic;

namespace SRC.HelloWorld.Repository.Cat
{
    public interface ICatRepository
    {
        List<SRC.HelloWorld.Data.Model.Cat> LoadAll();
    }
}