using eHub.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHub.Common.Api
{
    public interface IPoolApi
    {
        Task<IEnumerable<string>> SetSchedule(DateTime startTime, DateTime endTime);
        Task<IEnumerable<PiPin>> GetAllStatuses();
        Task<PiPin> GetStatus(EquipmentType equipmentType);
    }
}
