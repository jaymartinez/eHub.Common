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

        /// <summary>
        /// The GPIO pin number
        /// </summary>
        [DataMember]
        public int PinNumber { get; set; }

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
                switch (PinNumber)
                {
                    case Pin.PoolPump_1:
                    case Pin.PoolPump_2:
                        return "Pool Pump";
                    case Pin.SpaPump_1:
                    case Pin.SpaPump_2:
                        return "Spa Pump";
                    case Pin.BoosterPump_1:
                    case Pin.BoosterPump_2:
                        return "Booster Pump";
                    case Pin.Heater:
                        return "Heater";
                    case Pin.PoolLight:
                        return "Pool Light";
                    case Pin.SpaLight:
                        return "Spa Light";
                    case Pin.GroundLights:
                        return "Ground Lights";
                    default:
                        return "Unknown";
                }
            }
        }
    }
}
