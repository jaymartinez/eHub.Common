using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eHub.Common.Models
{
    [DataContract]
    public class Response<T>
    {
        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public List<string> Messages { get; set; } = new List<string>();
    }
}
