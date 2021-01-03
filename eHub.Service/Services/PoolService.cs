using eHub.Common.Api;
using eHub.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHub.Common.Services
{
    public class PoolService : IPoolService
    {
        readonly IPoolApi _api;

        public PoolService(IPoolApi api)
        {
            _api = api;
        }

        public async Task<IEnumerable<PiPin>> GetAllStatuses()
        {
            var result = await _api.GetAllStatuses();
            return result ?? Enumerable.Empty<PiPin>();
        }

        public async Task<PiPin> GetPinStatus(int pin)
        {
            return await _api.GetStatus(pin);
        }

        public async Task<PoolSchedule> GetSchedule()
        {
            var result = await _api.GetSchedule();
            return result;
        }

        public async Task<int> GetMasterSwitchStatus()
        {
            return await _api.GetMasterSwitchStatus();
        }

        public async Task<bool> Ping()
        {
            return await _api.Ping();
        }

        public async Task<PoolSchedule> SetSchedule(DateTime startTime, DateTime endTime, bool isActive, bool includeBooster)
        {
            try
            {
                string startDateStr = startTime.ToString(@"MM\/dd\/yyyy HH:mm");
                string endDateStr = endTime.ToString(@"MM\/dd\/yyyy HH:mm");
                return await _api.SetSchedule(startDateStr, endDateStr, isActive, includeBooster);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PiPin> Toggle(int pin)
        {
            return await _api.Toggle(pin);
        }

        public async Task<int> ToggleMasterSwitch()
        {
            return await _api.ToggleMasterSwitch();
        }

        public async Task<int> ToggleIncludeBoosterSwitch()
        {
            return await _api.ToggleIncludeBoosterSwitch();
        }
    }
}
