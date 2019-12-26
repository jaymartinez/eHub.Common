using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eHub.Services.Core.Models
{
    [DataContract]
    public class Response<T>
    {
        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public List<string> messages { get; set; }
    }
}
