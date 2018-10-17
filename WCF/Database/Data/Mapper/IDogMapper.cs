
namespace WCF.Database.Data.Mapper
{
    public interface IDogMapper
    {
        API.Contracts.Dog.Model.Dog Map(WCF.Database.Data.Model.Dog dog);
    }
}
