using System.Runtime.Serialization;

namespace API.Contracts.Cat.Messaging
{
    [DataContract]
    public class GetCatResp : Resp
    {
        [DataMember]
        public Model.Cat Cat { get; set; }
    }
}
