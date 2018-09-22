using System.Runtime.Serialization;

namespace API.Contracts
{
    [DataContract]
    public class ExceptionError
    {
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string StackTrace { get; set; }
    }
}