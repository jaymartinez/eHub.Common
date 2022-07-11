using System;
using System.Runtime.Serialization;

namespace eHub.Common.Models
{
    [Serializable]
    public class EquipmentSchedule
    {
        [DataMember]
        public ScheduleType Type { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public TimeSpan StartTime { get; set; } = new TimeSpan(8, 30, 0); 

        [DataMember]
        public TimeSpan EndTime { get; set; } = new TimeSpan(14, 30, 0); 
    }
}
