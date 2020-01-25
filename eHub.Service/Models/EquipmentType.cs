
using System;
using System.Xml.Serialization;

namespace eHub.Common.Models
{
    public enum EquipmentType
    {
        [XmlEnum("5")] PoolPump = 5,
        [XmlEnum("6")] SpaPump = 6,
        [XmlEnum("17")] Heater = 17,
        [XmlEnum("18")] BoosterPump = 18,
        [XmlEnum("19")] PoolLight = 19,
        [XmlEnum("20")] SpaLight = 20,
        [XmlEnum("21")] GroundLights = 21
    }
}
