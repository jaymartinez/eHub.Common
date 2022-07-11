using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eHub.Common.Models
{
    [Serializable]
    public class LightServerModel : PiPin
    {
        [DataMember]
        public EquipmentSchedule Schedule {  get; set; }

        [DataMember]
        public LightModeType CurrentMode { get; set; }

        [DataMember]
        public LightModeType? PreviousMode { get; set; } = LightModeType.NotSet;

        [DataMember]
        public LightType LightType { get; set; }
    }
}
