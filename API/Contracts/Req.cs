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
            // SecurityToken = SecurityTokenUtil.GetSecurityToken();
        }

        [DataMember]
        public IList<Header> Headers { get; set; }

        // [DataMember]
        // public Identity Identity { get; set; }

        [DataMember]
        public string SecurityToken { get; set; }
    }
}
