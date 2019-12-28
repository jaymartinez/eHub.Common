using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eHub.Service.Core.Models;

namespace eHub.Service.Core.Api
{
    public class PoolApi : IPoolApi
    {
        readonly IWebInterface _webApi;

        public PoolApi(IWebInterface webInterface)
        {
            _webApi = webInterface;
        }

        public async Task<Response<PiPin>> GetStatus(EquipmentType equipmentType)
        {
            var result = await _webApi.Get<PiPin>($"status?pinNumber={(int)equipmentType}");
            return result;
        }

        public async Task<Response<List<PiPin>>> GetAllStatuses()
        {
            var result = await _webApi.Get<List<PiPin>>("/allStatuses");
            return result;
        }

        public async Task<List<string>> SetSchedule(DateTime startTime, DateTime endTime)
        {
            string startDateStr = startTime.ToString(@"MM\/dd\/yyyy HH:mm");
            string endDateStr = endTime.ToString(@"MM\/dd\/yyyy HH:mm");

            throw new NotImplementedException();
        }
    }
}
