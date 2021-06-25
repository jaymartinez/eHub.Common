
using eHub.Common.Models;

namespace eHub.Common.Helpers
{
    public static class Extensions
    {
        public static string ToLightModeText(this PoolLightMode mode)
        {
            switch (mode)
            {
                case PoolLightMode.Sam:
                    return "SAM Mode";
                case PoolLightMode.Party:
                    return "Party Mode";
                case PoolLightMode.Romance:
                    return "Romance Mode";
                case PoolLightMode.Caribbean:
                    return "Caribbean Mode";
                case PoolLightMode.American:
                    return "American Mode";
                case PoolLightMode.CaliforniaSunset:
                    return "California Sunset Mode";
                case PoolLightMode.Royal:
                    return "Royal Mode";
                case PoolLightMode.Blue:
                    return "Blue Fixed Mode";
                case PoolLightMode.Green:
                    return "Green Fixed Mode";
                case PoolLightMode.Red:
                    return "Red Fixed Mode";
                case PoolLightMode.White:
                    return "White Fixed Mode";
                case PoolLightMode.Magenta:
                    return "Magenta Fixed Mode";
                case PoolLightMode.Hold:
                    return "Holding current color from light show";
                case PoolLightMode.Recall:
                    return "Recall the last saved color effect";
                default:
                    return "Light mode not set";
            }
        }
    }
}