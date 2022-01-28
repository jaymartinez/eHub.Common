
using eHub.Common.Models;

namespace eHub.Common.Helpers
{
    public static class Extensions
    {
        public static string ToLightModeText(this LightModeType mode)
        {
            switch (mode)
            {
                case LightModeType.Sam:
                    return "SAM Mode";
                case LightModeType.Party:
                    return "Party Mode";
                case LightModeType.Romance:
                    return "Romance Mode";
                case LightModeType.Caribbean:
                    return "Caribbean Mode";
                case LightModeType.American:
                    return "American Mode";
                case LightModeType.CaliforniaSunset:
                    return "California Sunset Mode";
                case LightModeType.Royal:
                    return "Royal Mode";
                case LightModeType.Blue:
                    return "Blue Fixed Mode";
                case LightModeType.Green:
                    return "Green Fixed Mode";
                case LightModeType.Red:
                    return "Red Fixed Mode";
                case LightModeType.White:
                    return "White Fixed Mode";
                case LightModeType.Magenta:
                    return "Magenta Fixed Mode";
                case LightModeType.Hold:
                    return "Holding current color from light show";
                case LightModeType.Recall:
                    return "Recall the last saved color effect";
                default:
                    return "Light mode not set";
            }
        }
    }
}