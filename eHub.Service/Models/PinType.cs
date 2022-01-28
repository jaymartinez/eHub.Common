﻿

namespace eHub.Common.Models
{
    /// <summary>
    /// Identifies the equipment associated with the gpio pin assignment
    /// <code><list type="bullet">
    /// <item><see cref="PoolPump"/>: 1</item>
    /// <item><see cref="SpaPump"/>: 2</item>
    /// <item><see cref="BoosterPump"/>: 3</item>
    /// <item><see cref="Heater"/>: 4</item>
    /// <item><see cref="PoolLight"/>: 5</item>
    /// <item><see cref="SpaLight"/>: 6</item>
    /// <item><see cref="GroundLights"/>: 7</item>
    /// </list></code>
    /// </summary>
    public enum PinType : byte
    {
        PoolPump,
        SpaPump,
        BoosterPump,
        Heater,
        GroundLights,
        PoolLight,
        SpaLight
    }
}
