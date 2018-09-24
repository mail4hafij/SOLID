using System.Runtime.Serialization;

namespace API.Contracts.Dog.Messaging
{
    [DataContract]
    public class GetDogResp : Resp
    {
        [DataMember]
        public Model.Dog Dog { get; set; }
    }
}
