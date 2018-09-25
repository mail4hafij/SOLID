using API.Contracts.Cat.Messaging;
using API.Contracts.Dog.Messaging;
using System.ServiceModel;

namespace API
{
    [ServiceContract]
    public interface IAnimalService
    {
        [OperationContract]
        GetCatResp GetCat(GetCatReq req);

        [OperationContract]
        GetDogResp GetDog(GetDogReq req);
    }
}
