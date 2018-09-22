using System.Runtime.Serialization;

namespace API.Contracts.Cat.Model
{
    [DataContract]
    public class Cat
    {
        [DataMember]
        public string Color { get; set; }
    }
}