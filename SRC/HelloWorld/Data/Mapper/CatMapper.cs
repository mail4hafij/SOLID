
namespace SRC.HelloWorld.Data.Mapper
{
    public class CatMapper : ICatMapper
    {
        public API.Contracts.Cat.Model.Cat Map(SRC.HelloWorld.Data.Model.Cat cat)
        {
            return new API.Contracts.Cat.Model.Cat
            {
                Color = cat.Color
            };
        }
    }
}
