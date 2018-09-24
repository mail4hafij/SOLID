using System.Collections.Generic;
using System.Runtime.Serialization;

namespace API.Contracts
{
    [DataContract]
    public abstract class Req
    {
        protected Req()
        {
            Headers = new List<Header>();
        }

        [DataMember]
        public IList<Header> Headers { get; set; }
    }
}
