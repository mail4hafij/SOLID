
namespace SRC.HelloWorld.Data.Mapper
{
    public interface IDogMapper
    {
        API.Contracts.Dog.Model.Dog Map(SRC.HelloWorld.Data.Model.Dog dog);
    }
}
