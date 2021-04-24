using System;
using System.Runtime.Serialization;

namespace eHub.Common.Models
{
    [Serializable]
    public class PoolSchedule : EquipmentSchedule
    {
        [DataMember]
        public bool IncludeBooster { get; set; } = false;
    }
}
