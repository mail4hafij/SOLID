
namespace WCF.HelloWorld.Data.Mapper
{
    public interface ICatMapper
    {
        API.Contracts.Cat.Model.Cat Map(WCF.HelloWorld.Data.Model.Cat cat);
    }
}
