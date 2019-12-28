using System;
using System.Runtime.Serialization;

namespace eHub.Service.Core.Models
{
    [Serializable]
    public class PiPin
    {
        /// <summary>
        /// 0: The pin is low
        /// 1: The pin is high
        /// </summary>
        [DataMember]
        public PinState State { get; set; }

        /// <summary>
        /// The GPIO pin number
        /// </summary>
        [DataMember]
        public EquipmentType PinNumber { get; set; }

        [IgnoreDataMember]
        public string StateDescription
        {
            get
            {
                return State == PinState.ON ? "On" : "Off";
            }
        }

        
        
    }
}
