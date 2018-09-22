using System.Runtime.Serialization;

namespace API.Contracts.Dog.Model
{
    [DataContract]
    public class Dog
    {
        [DataMember]
        public string Color { get; set; }
    }
}