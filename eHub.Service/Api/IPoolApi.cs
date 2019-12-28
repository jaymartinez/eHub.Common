using eHub.Service.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHub.Service.Core.Api
{
    public interface IPoolApi
    {
        Task<List<string>> SetSchedule(DateTime startTime, DateTime endTime);
        Task<Response<List<PiPin>>> GetAllStatuses();
        Task<Response<PiPin>> GetStatus(EquipmentType equipmentType);
    }
}
