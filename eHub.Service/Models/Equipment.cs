
namespace eHub.Common.Models
{
    public class Equipment
    {
        public int PinNumber { get; }
        public string Title { get; }

        public Equipment(int pin)
        {
            PinNumber = pin;

            switch (pin)
            {
                case Pin.PoolPump:
                    Title = "Pool Pump";
                    break;
                case Pin.SpaPump:
                    Title = "Spa Pump";
                    break;
                case Pin.Heater:
                    Title = "Heater";
                    break;
                case Pin.BoosterPump:
                    Title = "Booster Pump";
                    break;
                case Pin.PoolLight:
                    Title = "Pool Light";
                    break;
                case Pin.SpaLight:
                    Title = "Spa Light";
                    break;
                case Pin.GroundLights:
                    Title = "Ground Lights";
                    break;
                default:
                    Title = "Unknown Equipment";
                    break;
            }
        }
    }
}
