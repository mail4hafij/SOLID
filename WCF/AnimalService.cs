using API;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using System.ServiceModel;
using WCF.LIB;

namespace WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AnimalService : ServiceBase, IAnimalService
    {
        public AnimalService(IHandlerCaller handlerCaller) : base(handlerCaller) { }

        public GetCatResp GetCat(GetCatReq req) => Process<GetCatReq, GetCatResp>(req);

        public GetDogResp GetDog(GetDogReq req) => Process<GetDogReq, GetDogResp>(req);

    }
}