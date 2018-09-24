using API.Contracts.Dog.Messaging;
using SRC.LIB;

namespace SRC.Handler.Dog
{
    public class GetDogHandler : RequestHandler<GetDogReq, GetDogResp>
    {
        public override GetDogResp Process(GetDogReq req)
        {
            return new GetDogResp() { Dog = new API.Contracts.Dog.Model.Dog() { Color = "Black" } };
        }
    }
}
