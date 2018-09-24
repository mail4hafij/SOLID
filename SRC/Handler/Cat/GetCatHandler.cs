using API.Contracts.Cat.Messaging;
using SRC.LIB;

namespace SRC.Handler.Cat
{
    public class GetCatHandler : RequestHandler<GetCatReq, GetCatResp>
    {
        public override GetCatResp Process(GetCatReq req)
        {
            return new GetCatResp() { Cat = new API.Contracts.Cat.Model.Cat() { Color = "White" } };
        }
    }
}
