using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eHub.Common.Models;

namespace eHub.Common.Api
{
    public class PoolApi : BaseApi, IPoolApi
    {
        readonly IWebInterface _webApi;

        public PoolApi(IWebInterface webInterface)
        {
            _webApi = webInterface;
        }

        public async Task<PiPin> GetStatus(EquipmentType equipmentType)
        {
            Response<PiPin> result = null;
            try
            {
                result = await _webApi.Get<Response<PiPin>>($"status?pinNumber={(int)equipmentType}");
            }
            catch (Exception e)
            {
                result.Messages.Add(e.Message);
            }

            HandleMessages(result.Messages ?? new List<string>());
            return result.Data ?? null;
        }

        public async Task<IEnumerable<PiPin>> GetAllStatuses()
        {
            var result = default(Response<IEnumerable<PiPin>>);

            try
            {
                result = await _webApi.Get<Response<IEnumerable<PiPin>>>("/allStatuses");
            }
            catch (Exception e)
            {
                result = new Response<IEnumerable<PiPin>>
                {
                    Data = null,
                    Messages = new List<string> { e.Message, e.StackTrace }
                };
            }
            
            HandleMessages(result.Messages ?? new List<string>());
            return result.Data ?? Enumerable.Empty<PiPin>();
        }

        public async Task<IEnumerable<string>> SetSchedule(DateTime startTime, DateTime endTime)
        {
            string startDateStr = startTime.ToString(@"MM\/dd\/yyyy HH:mm");
            string endDateStr = endTime.ToString(@"MM\/dd\/yyyy HH:mm");

            throw new NotImplementedException();
        }
    }
}
