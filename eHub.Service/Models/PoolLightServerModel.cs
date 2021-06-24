using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eHub.Common.Models
{
    [Serializable]
    public class PoolLightServerModel
    {
        [DataMember]
        public int CurrentMode { get; set; }

        [DataMember]
        public int PreviousMode { get; set; }

        [IgnoreDataMember]
        public PoolLightMode CurrentPoolLightMode => (PoolLightMode)CurrentMode;

        [IgnoreDataMember]
        public PoolLightMode PreviousPoolLightMode => (PoolLightMode)PreviousMode;

        [IgnoreDataMember]
        public LightType LightType { get; set; }
    }

    public enum LightType
    {
        Pool,
        Spa
    }
}
