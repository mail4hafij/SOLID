using System.Runtime.Serialization;

namespace API.Contracts.Models
{
    [DataContract]
    public class Dog
    {
        [DataMember]
        public string Color { get; set; }
    }
}