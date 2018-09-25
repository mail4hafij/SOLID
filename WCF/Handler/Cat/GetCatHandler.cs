using API.Contracts.Cat.Messaging;
using WCF.LIB;

namespace WCF.Handler.Cat
{
    public class GetCatHandler : RequestHandler<GetCatReq, GetCatResp>
    {
        public override GetCatResp Process(GetCatReq req)
        {
            return new GetCatResp() { Cat = new API.Contracts.Cat.Model.Cat() { Color = "White" } };
        }
    }
}
