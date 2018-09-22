using System.Collections.Generic;
using System.Runtime.Serialization;

namespace API.Contracts
{
    [DataContract]
    public class Resp
    {
        public Resp()
        {
            Headers = new List<Header>();
            Success = true;
        }

        [DataMember]
        public IList<Header> Headers { get; set; }

        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public ExceptionError ExceptionError { get; set; }
    }
}
