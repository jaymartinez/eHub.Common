using System.Collections.Generic;
using System.Runtime.Serialization;

namespace eHub.Service.Core.Models
{
    [DataContract]
    public class Response<T>
    {
        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public List<string> Messages { get; set; }
    }
}
