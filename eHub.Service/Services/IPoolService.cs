using eHub.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHub.Common.Services
{
    public interface IPoolService
    {
        /// <summary>
        /// Gets the status for a piece of equipment
        /// </summary>
        /// <param name="pinType">The <see cref="PinType"/> to get the status for.</param>
        Task<PiPin> GetPinStatus(PinType pinType);

        /// <summary>
        /// Gets statuses for all pins in use.
        /// </summary>
        /// <returns><see cref="PiPin"/></returns>
        Task<IEnumerable<PiPin>> GetAllStatuses();

        Task<PoolSpaModel> GetPool();
        Task<PoolSpaModel> GetSpa();
        Task<BoosterPumpModel> GetBoosterPump();
        Task<HeaterModel> GetHeater();
        Task<PoolSpaModel> SavePool(PoolSpaModel poolModel);
        Task<PoolSpaModel> SaveSpa(PoolSpaModel spaModel);
        Task<BoosterPumpModel> SaveBoosterPump(BoosterPumpModel boosterPumpModel);
        Task<HeaterModel> SaveHeater(HeaterModel heaterModel);

        /// <summary>
        /// Heartbeat check.
        /// </summary>
        /// <returns>True if the ping succeeded.</returns>
        Task<bool> Ping();

        /// <summary>
        /// Set timer schedule for pool, booster, lights
        /// </summary>
        /// <param name="schedule">The schedule to set</param>
        /// <returns>The schedule that was saved to the server.</returns>
        Task<EquipmentSchedule> SetSchedule(EquipmentSchedule schedule);

        /// <summary>
        /// Get timer schedule for the passed in <see cref="ScheduleType"/>
        /// </summary>
        /// <param name="scheduleType">The <see cref="ScheduleType"/> to get the schedule of</param>
        /// <returns></returns>
        Task<EquipmentSchedule> GetSchedule(ScheduleType scheduleType);

        /// <summary>
        /// Toggle equipment on or off depending on it's current state on the server
        /// </summary>
        /// <param name="pinType">The <see cref="PinType"/> to toggle</param>
        /// <returns>Current state of the equipment after successfully toggling it</returns>
        Task<PiPin> Toggle(PinType pinType);

        /// <summary>
        /// Enables/disables the schedule.
        /// </summary>
        /// <returns></returns>
        Task<int> ToggleMasterSwitch();

        Task<int> ToggleIncludeBoosterSwitch();
        Task<int> GetMasterSwitchStatus();

        /// <summary>
        /// Get current light mode for pool or spa
        /// </summary>
        /// <param name="lightType">The <see cref="LightType"/> either pool or spa</param>
        /// <returns></returns>
        Task<LightServerModel> GetCurrentLightMode(LightType lightType);

        /// <summary>
        /// Save light mode for passed in type
        /// </summary>
        /// <param name="mode">The <see cref="LightModeType"/> to save</param>
        /// <param name="lightType">Whether we are saving the mode type for pool or spa light</param>
        /// <returns><see cref="LightServerModel"/> representing the current light state after a successful save</returns>
        Task<LightServerModel> SaveLightMode(LightModeType mode, LightType lightType);

        Task<WaterTemp> GetWaterTemp();
    }
}
