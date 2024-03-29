﻿using eHub.Common.Models;
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
        /// Gets the pool timer schedule
        /// </summary>
        /// <returns></returns>
        Task<PoolSchedule> GetSchedule();
        Task<EquipmentSchedule> GetBoosterSchedule();

        /// <summary>
        /// Sets the main pool schedule.
        /// Ideally we could have a schedule for each piece of equipment.
        /// </summary>
        /// <param name="startTime">When to start the pump.</param>
        /// <param name="endTime">When to stop the pump.</param>
        /// <returns>The schedule that was just saved.</returns>
        Task<PoolSchedule> SetSchedule(DateTime startTime, DateTime endTime, bool isActive, bool includeBooster);
        Task<EquipmentSchedule> SetBoosterSchedule(DateTime startTime, DateTime endTime, bool isActive);

        /// <summary>
        /// Gets the pool light schedule
        /// </summary>
        Task<EquipmentSchedule> GetPoolLightSchedule();

        /// <summary>
        /// Sets the pool light schedule
        /// </summary>
        /// <returns>The schedule that was just saved.</returns>
        Task<EquipmentSchedule> SetPoolLightSchedule(DateTime startTime, DateTime endTime, bool isActive);


        /// <summary>
        /// Gets the ground lights schedule
        /// </summary>
        Task<EquipmentSchedule> GetGroundLightSchedule();

        /// <summary>
        /// Sets the ground lights schedule
        /// </summary>
        /// <returns>The schedule that was just saved.</returns>
        Task<EquipmentSchedule> SetGroundLightSchedule(DateTime startTime, DateTime endTime, bool isActive);

        Task<EquipmentSchedule> GetSpaLightSchedule();
        Task<EquipmentSchedule> SetSpaLightSchedule(DateTime startTime, DateTime endTime, bool isActive);

        Task<PiPin> Toggle(int pin);

        /// <summary>
        /// Enables/disables the schedule.
        /// </summary>
        /// <returns></returns>
        Task<int> ToggleMasterSwitch();

        Task<int> ToggleIncludeBoosterSwitch();
        Task<int> GetMasterSwitchStatus();
        Task<PoolLightServerModel> GetCurrentPoolLightMode();
        Task<PoolLightServerModel> SavePoolLightMode(PoolLightMode mode);
        Task<PoolLightServerModel> GetCurrentSpaLightMode();
        Task<PoolLightServerModel> SaveSpaLightMode(PoolLightMode mode);
        Task<WaterTemp> GetWaterTemp();
    }
}
