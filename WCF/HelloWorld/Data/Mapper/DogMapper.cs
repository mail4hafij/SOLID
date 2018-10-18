
namespace WCF.HelloWorld.Data.Mapper
{
    public class DogMapper : IDogMapper
    {
        public API.Contracts.Dog.Model.Dog Map(WCF.HelloWorld.Data.Model.Dog dog)
        {
            return new API.Contracts.Dog.Model.Dog
            {
                Color = dog.Color
            };
        }
    }
}
