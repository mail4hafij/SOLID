using API.Contracts;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;

namespace SRC
{
    public class AnimalService : ServiceBase, IAnimalService
    {
        public AnimalService(IHandlerCaller handlerCaller) : base(handlerCaller) { }

        public GetCatResp GetCat(GetCatReq req) => Process<GetCatReq, GetCatResp>(req);

        public GetDogResp GetDog(GetDogReq req) => Process<GetDogReq, GetDogResp>(req);

    }
}
