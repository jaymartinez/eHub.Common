using eHub.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHub.Common.Api
{
    public interface IPoolApi
    {
        Task<PoolSchedule> GetSchedule();
        Task<PoolSchedule> SetSchedule(string startTimeStr, string endTimeStr, bool isActive, bool includeBooster);
        Task<IEnumerable<PiPin>> GetAllStatuses();
        Task<PiPin> GetStatus(int pin);
        Task<bool> Ping();
        Task<PiPin> Toggle(int pin);
        Task<int> ToggleMasterSwitch();
        Task<int> ToggleIncludeBoosterSwitch();
        Task<int> GetMasterSwitchStatus();
    }
}
