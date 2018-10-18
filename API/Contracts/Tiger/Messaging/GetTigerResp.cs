using System.Runtime.Serialization;

namespace API.Contracts.Tiger.Messaging
{
    [DataContract]
    public class GetTigerResp : Resp
    {
        [DataMember]
        public Model.Tiger Tiger { get; set; }
    }
}
