
using System;

namespace eHub.Common.Models
{
    /// <summary>
    /// Identifies the type of schedule
    /// <code><list type="bullet">
    /// <item><see cref="Booster"/>: 1</item>
    /// <item><see cref="Pool"/>: 2</item>
    /// <item><see cref="PoolLight"/>: 3</item>
    /// <item><see cref="SpaLight"/>: 4</item>
    /// </list></code>
    /// </summary>
    [Serializable]
    public enum ScheduleType : byte
    {
        Invalid = 0,
        Booster = 1,
        Pool = 2,
        PoolLight = 3,
        SpaLight = 4,
        GroundLights = 5,
    }
}
