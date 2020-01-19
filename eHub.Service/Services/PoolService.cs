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

        public async Task<PiPin> GetPinStatus(EquipmentType equipmentType)
        {
            return await _api.GetStatus(equipmentType);
        }

        public Task<IEnumerable<string>> SetSchedule(DateTime startTime, DateTime endTime)
        {
            return null;
        }
    }
}
