
namespace WCF.Database.Data.Mapper
{
    public class DogMapper : IDogMapper
    {
        public API.Contracts.Dog.Model.Dog Map(WCF.Database.Data.Model.Dog dog)
        {
            return new API.Contracts.Dog.Model.Dog
            {
                Color = dog.Color
            };
        }
    }
}
