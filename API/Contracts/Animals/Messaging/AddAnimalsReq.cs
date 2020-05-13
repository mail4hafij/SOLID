using System;
using System.Runtime.Serialization;

namespace API.Contracts.Animals.Messaging
{
    [DataContract]
    public class AddAnimalsReq : Req
    {
        [DataMember]
        public String CatColor { get; set; }

        [DataMember]
        public String DogColor { get; set; }
    }
}
