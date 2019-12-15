
namespace SRC.HelloWorld.Data.Mapper
{
    public interface ICatMapper
    {
        API.Contracts.Cat.Model.Cat Map(SRC.HelloWorld.Data.Model.Cat cat);
    }
}
