using System.Runtime.Serialization;

namespace API.Contracts
{
    [DataContract]
    public class Header
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}