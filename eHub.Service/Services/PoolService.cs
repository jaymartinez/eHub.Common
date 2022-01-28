using eHub.Common.Api;
using eHub.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eHub.Common.Services
{
    public class PoolService : ServiceBase, IPoolService
    {
        readonly IWebInterface _api;

        public PoolService(IWebInterface api)
        {
            _api = api;
        }

        public override void HandleMessages(List<string> messages)
        {
            //TODO - do something better than just write to console
            Console.WriteLine(">>> Handling Messages from Response.");
            foreach (var m in messages)
            {
                Console.WriteLine("\n\t" + m);
            }
        }

        public async Task<IEnumerable<PiPin>> GetAllStatuses()
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Get<Response<IEnumerable<PiPin>>>("/allStatuses");
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? Enumerable.Empty<PiPin>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> GetMasterSwitchStatus()
        {
            try
            {
                var result = await _api.Get<Response<int>>("masterSwitchStatus");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PiPin> Toggle(PinType pinType)
        {
            try
            {
                var toggle = await _api.Get<Response<PiPin>>($"toggle?pinType={pinType}");
                HandleMessages(toggle?.Messages ?? new List<string>());
                return toggle?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> ToggleMasterSwitch()
        {
            try
            {
                var result = await _api.Get<Response<int>>("toggleMasterSwitch");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> ToggleIncludeBoosterSwitch()
        {
            try
            {
                var result = await _api.Get<Response<int>>("toggleIncludeBoosterSwitch");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Ping() 
        {
            try
            {
                var result = await _api.Get<Response<IEnumerable<string>>>("ping");
                if (result?.Messages?.Count() == 1 && result.Messages.ElementAt(0).ToLower().Equals("ok"))
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<WaterTemp> GetWaterTemp()
        {
            try
            {
                var result = await _api.GetWaterTemp("watertemp");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new WaterTemp() { ValueF = 0, ValueC = 0 };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PiPin> GetPinStatus(PinType pinType)
        {
            var result = new Response<PiPin>();
            try
            {
                result = await _api.Get<Response<PiPin>>($"status?pinType={pinType}");
            }
            catch (Exception e)
            {
                result.Messages.Add(e.Message);
            }

            HandleMessages(result?.Messages ?? new List<string>());

            return result?.Data ?? null;
        }

        public async Task<EquipmentSchedule> SetSchedule(EquipmentSchedule schedule)
        {
            try
            {
                var result = await _api.Post<Response<EquipmentSchedule>>("setSchedule", schedule);

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EquipmentSchedule> GetSchedule(ScheduleType scheduleType)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Get<Response<EquipmentSchedule>>($"getSchedule?scheduleType={scheduleType}");
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<LightServerModel> GetCurrentLightMode(LightType lightType)
        {
            try
            {
                var result = await _api.Get<Response<LightServerModel>>($"getCurrentLightMode?lightType={lightType}");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new LightServerModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<LightServerModel> SaveLightMode(LightModeType mode, LightType lightType)
        {
            try
            {
                var result = await _api.Get<Response<LightServerModel>>($"saveLightMode?lightMode={mode}&lightType={lightType}");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new LightServerModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
