using API.Contracts.Models;
using System.ServiceModel;

namespace API.Contracts
{
    [ServiceContract]
    public interface IAnimalService
    {
        [OperationContract]
        Cat GetCat();

        [OperationContract]
        Dog GetDog();
    }
}
