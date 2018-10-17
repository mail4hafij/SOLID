
namespace WCF.Database.Data.Mapper
{
    public class CatMapper : ICatMapper
    {
        public API.Contracts.Cat.Model.Cat Map(WCF.Database.Data.Model.Cat cat)
        {
            return new API.Contracts.Cat.Model.Cat
            {
                Color = cat.Color
            };
        }
    }
}
