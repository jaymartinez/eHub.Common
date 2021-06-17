using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eHub.Common.Models
{
    [Serializable]
    public class WaterTemp
    {
        /// <summary>
        /// Temperature value in Fahrenheit
        /// </summary>
        [DataMember]
        public double ValueF { get; set; }

        /// <summary>
        /// Temperature value in Celcius
        /// </summary>
        [DataMember]
        public double ValueC { get; set; }

        [IgnoreDataMember]
        public string TemperatureCelcius => $"{ValueC}\u00B0 C";

        [IgnoreDataMember]
        public string TemperatureFahrenheit => $"{ValueF}\u00B0 F";
    }
}
