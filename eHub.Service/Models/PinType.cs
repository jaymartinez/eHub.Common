

namespace eHub.Common.Models
{
    /// <summary>
    /// Identifies the equipment associated with the gpio pin assignment
    /// <code><list type="bullet">
    /// <item><see cref="PoolPump"/>: 5</item>
    /// <item><see cref="SpaPump"/>: 23</item>
    /// <item><see cref="BoosterPump"/>: 12</item>
    /// <item><see cref="Heater"/>: 17</item>
    /// <item><see cref="PoolLight"/>: 19</item>
    /// <item><see cref="SpaLight"/>: 20</item>
    /// <item><see cref="GroundLights"/>: 21</item>
    /// </list></code>
    /// </summary>
    public enum PinType : byte
    {
        Undefined = 0,
        PoolPump = 5,
        SpaPump = 23,
        BoosterPump = 12,
        Heater = 17,
        PoolLight = 19,
        SpaLight = 20,
        GroundLights = 21
    }
}
