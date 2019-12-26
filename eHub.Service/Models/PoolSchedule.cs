using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eHub.Services.Core.Models
{
    [Serializable]
    public class PoolSchedule
    {
        [DataMember]
        public int StartHour { get; set; } = 8;

        [DataMember]
        public int StartMinute { get; set; } = 30;

        [DataMember]
        public int EndHour { get; set; } = 14;

        [DataMember]
        public int EndMinute { get; set; } = 30;
    }
}
