using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eHub.Common.Models
{
    [Serializable]
    public class PoolSpaModel : PiPin
    {
        [DataMember]
        public EquipmentSchedule Schedule { get; set; }

        [DataMember]
        public LightServerModel Light { get; set; }
    }
}
