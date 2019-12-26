using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace eHub.Services.Core.Models
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
        public Equipment PinNumber { get; set; }

        [IgnoreDataMember]
        public string StateDescription
        {
            get
            {
                return State == PinState.ON ? "On" : "Off";
            }
        }

        [IgnoreDataMember]
        public string EquipmentName
        {
            get
            {
                switch (PinNumber)
                {
                    case Equipment.PoolPump:
                        return "Pool Pump";
                    case Equipment.SpaPump:
                        return "Spa Pump";
                    case Equipment.Heater:
                        return nameof(Equipment.Heater);
                    case Equipment.BoosterPump:
                        return "Booster Pump";
                    case Equipment.PoolLight:
                        return "Pool Light";
                    case Equipment.SpaLight:
                        return "Spa Light";
                    case Equipment.GroundLights:
                        return "Ground Lights";
                    default:
                        return "Unknown Equipment";
                }
            }
        }
    }
}
