
namespace WCF.HelloWorld.Data.Mapper
{
    public interface IDogMapper
    {
        API.Contracts.Dog.Model.Dog Map(WCF.HelloWorld.Data.Model.Dog dog);
    }
}
