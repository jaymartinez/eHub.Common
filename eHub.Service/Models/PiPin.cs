using System;
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
        /// </summary>C:\dev\eHub.Common\eHub.Service\Models\PiPin.cs
        [DataMember]
        public int PinNumber { get; set; }

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
