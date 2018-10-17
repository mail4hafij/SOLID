
namespace WCF.Database.Data.Mapper
{
    public interface ICatMapper
    {
        API.Contracts.Cat.Model.Cat Map(WCF.Database.Data.Model.Cat cat);
    }
}
