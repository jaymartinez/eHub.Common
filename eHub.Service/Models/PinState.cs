
using System;
using System.Xml.Serialization;

namespace eHub.Common.Models
{
    [Serializable]
    public enum PinState
    {
        [XmlEnum("0")] OFF = 0,
        [XmlEnum("1")] ON = 1
    }
}
