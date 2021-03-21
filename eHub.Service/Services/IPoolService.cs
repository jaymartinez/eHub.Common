using eHub.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHub.Common.Services
{
    public interface IPoolService
    {
        /// <summary>
        /// Gets the status for a pin.
        /// </summary>
        /// <param name="equipmentType">The equipment to get the status for.</param>
        Task<PiPin> GetPinStatus(int pin);

        /// <summary>
        /// Gets statuses for all pins in use.
        /// </summary>
        /// <returns><see cref="PiPin"/></returns>
        Task<IEnumerable<PiPin>> GetAllStatuses();

        /// <summary>
        /// Heartbeat check.
        /// </summary>
        /// <returns>True if the ping succeeded.</returns>
        Task<bool> Ping();

        /// <summary>
        /// Sets the main pool schedule.
        /// Ideally we could have a schedule for each piece of equipment.
        /// </summary>
        /// <param name="startTime">When to start the pump.</param>
        /// <param name="endTime">When to stop the pump.</param>
        /// <returns>The schedule that was just saved.</returns>
        Task<PoolSchedule> SetSchedule(DateTime startTime, DateTime endTime, bool isActive, bool includeBooster);

        Task<PoolSchedule> GetSchedule();

        Task<PiPin> Toggle(int pin);

        /// <summary>
        /// Enables/disables the schedule.
        /// </summary>
        /// <returns></returns>
        Task<int> ToggleMasterSwitch();

        Task<int> ToggleIncludeBoosterSwitch();
        Task<int> GetMasterSwitchStatus();
        Task<PoolLightServerModel> GetCurrentPoolLightMode();
        Task<PoolLightMode> SavePoolLightMode(PoolLightMode mode);
    }
}
