using API;
using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;


namespace WCFIIS
{
    public class AnimalService : IAnimalService
    {
        public GetCatResp GetCat(GetCatReq req)
        {
            return new GetCatResp() { Cat = new API.Contracts.Cat.Model.Cat() { Color = "White" } };
        }

        public GetDogResp GetDog(GetDogReq req)
        {
            return new GetDogResp() { Dog = new API.Contracts.Dog.Model.Dog() { Color = "Black" } };
        }

    }
}