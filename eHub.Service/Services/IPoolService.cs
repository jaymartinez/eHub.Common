using eHub.Service.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHub.Service.Core.Services
{
    public interface IPoolService
    {
        /// <summary>
        /// Gets the status for a pin.
        /// </summary>
        /// <param name="equipmentType">The equipment to get the status for.</param>
        Task<PiPin> GetPinStatus(EquipmentType equipmentType);

        /// <summary>
        /// Gets statuses for all pins in use.
        /// </summary>
        /// <returns><see cref="PiPin"/></returns>
        Task<IEnumerable<PiPin>> GetAllStatuses();

        /// <summary>
        /// Sets the main pool schedule.
        /// Ideally we could have a schedule for each piece of equipment.
        /// </summary>
        /// <param name="startTime">When to start the pump.</param>
        /// <param name="endTime">When to stop the pump.</param>
        /// <returns>List of messages from the server.</returns>
        Task<IEnumerable<string>> SetSchedule(DateTime startTime, DateTime endTime);
    }
}
