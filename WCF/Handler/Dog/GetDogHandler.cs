using API.Contracts.Dog.Messaging;
using WCF.LIB;

namespace WCF.Handler.Dog
{
    public class GetDogHandler : RequestHandler<GetDogReq, GetDogResp>
    {
        public override GetDogResp Process(GetDogReq req)
        {
            return new GetDogResp() { Dog = new API.Contracts.Dog.Model.Dog() { Color = "Black" } };
        }
    }
}
