using API;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using API.Contracts.Tiger.Messaging;

namespace WCFIIS
{
    
    public class AnimalService : IAnimalService
    {
        public GetCatResp GetCat(GetCatReq req)
        {
            return new GetCatResp() { Cat = new API.Contracts.Cat.Model.Cat() { Color = "Hello" } };
        }

        public GetDogResp GetDog(GetDogReq req)
        {
            return new GetDogResp() { Dog = new API.Contracts.Dog.Model.Dog() { Color = "World" } };
        }

        public GetTigerResp GetTiger(GetTigerReq req)
        {
            return new GetTigerResp() { Tiger = new API.Contracts.Tiger.Model.Tiger() { Color = "Lipsum" } };
        }
    }
}