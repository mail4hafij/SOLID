using System.Runtime.Serialization;

namespace API.Contracts.Tiger.Model
{
    [DataContract]
    public class Tiger
    {
        [DataMember]
        public string Color { get; set; }
    }
}