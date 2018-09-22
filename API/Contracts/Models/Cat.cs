using System.Runtime.Serialization;

namespace API.Contracts.Models
{
    [DataContract]
    public class Cat
    {
        [DataMember]
        public string Color { get; set; }
    }
}