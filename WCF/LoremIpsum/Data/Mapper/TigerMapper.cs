
namespace WCF.LoremIpsum.Data.Mapper
{
    public class TigerMapper : ITigerMapper
    {
        public API.Contracts.Tiger.Model.Tiger Map(WCF.LoremIpsum.Data.Model.Tiger tiger)
        {
            return new API.Contracts.Tiger.Model.Tiger
            {
                Color = tiger.Color
            };
        }
    }
}
