using System.Collections.Generic;

namespace SRC.HelloWorld.Repository.Dog
{
    public interface IDogRepository
    {
        List<SRC.HelloWorld.Data.Model.Dog> LoadAll();
    }
}
