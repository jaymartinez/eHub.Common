using eHub.Service.Core.Api;
using eHub.Service.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHub.Service.Core.Services
{
    public class PoolService : BaseService, IPoolService
    {
        readonly IPoolApi _api;

        public PoolService(IPoolApi api)
        {
            _api = api;
        }

        public async Task<IEnumerable<PiPin>> GetAllStatuses()
        {
            var response = await _api.GetAllStatuses();

            if (response == null
                || response.Data == null)
            {
                return null;
            }

            return response.Data;
        }

        public async Task<PiPin> GetPinStatus(EquipmentType equipmentType)
        {
            var response = await _api.GetStatus(equipmentType);
            if (response == null
                || response.Data == null)
            {
                HandleMessages(response.Messages);
            }

            return response.Data;
        }

        public Task<IEnumerable<string>> SetSchedule(DateTime startTime, DateTime endTime)
        {
            return null;
        }
    }
}
