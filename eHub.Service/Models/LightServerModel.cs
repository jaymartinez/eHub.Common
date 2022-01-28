using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eHub.Common.Models
{
    [Serializable]
    public class LightServerModel
    {
        [DataMember]
        public LightModeType CurrentMode { get; set; }  

        [DataMember]
        public LightModeType PreviousMode { get; set; }

        [DataMember]
        public LightType LightType { get; set; }
    }
}
