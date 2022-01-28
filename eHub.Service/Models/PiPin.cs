using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace eHub.Common.Models
{
    [Serializable]
    public class PiPin
    {
        /// <summary>
        /// 0: The pin is low
        /// 1: The pin is high
        /// </summary>
        [DataMember]
        public int State { get; set; }

        [DataMember]
        public PinType PinType { get; set; }

        [DataMember]
        public DateTime DateActivated { get; set; }

        [DataMember]
        public DateTime DateDeactivated { get; set; }

        [IgnoreDataMember]
        public string StateDescription
        {
            get
            {
                return State == PinState.ON ? "On" : "Off";
            }
        }

        [IgnoreDataMember]
        public string Name
        {
            get
            {
                switch (PinType)
                {
                    case PinType.PoolPump:
                        return "Pool Pump";
                    case PinType.SpaPump:
                        return "Spa Pump";
                    case PinType.BoosterPump:
                        return "Booster Pump";
                    case PinType.Heater:
                        return "Heater";
                    case PinType.PoolLight:
                        return "Pool Light";
                    case PinType.SpaLight:
                        return "Spa Light";
                    case PinType.GroundLights:
                        return "Ground Lights";
                    default:
                        return "Unknown";
                }
            }
        }
    }
}
