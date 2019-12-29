
namespace eHub.Common.Models
{
    public class Equipment
    {
        public EquipmentType Type { get; }
        public string Title { get; }

        public Equipment(EquipmentType type)
        {
            Type = type;

            switch (Type)
            {
                case EquipmentType.PoolPump:
                    Title = "Pool Pump";
                    break;
                case EquipmentType.SpaPump:
                    Title = "Spa Pump";
                    break;
                case EquipmentType.Heater:
                    Title = nameof(EquipmentType.Heater);
                    break;
                case EquipmentType.BoosterPump:
                    Title = "Booster Pump";
                    break;
                case EquipmentType.PoolLight:
                    Title = "Pool Light";
                    break;
                case EquipmentType.SpaLight:
                    Title = "Spa Light";
                    break;
                case EquipmentType.GroundLights:
                    Title = "Ground Lights";
                    break;
                default:
                    Title = "Unknown Equipment";
                    break;
            }
        }
    }
}
