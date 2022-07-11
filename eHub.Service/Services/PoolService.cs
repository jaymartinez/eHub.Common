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
        const string prefix = "api/mobile/";

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

        [Obsolete("WE NEED TO CREATE A BETTER EQUIPMENT OBJECT!!!!")]
        public async Task<IEnumerable<PiPin>> GetAllStatuses()
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Get<Response<IEnumerable<PiPin>>>($"{prefix}status");
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
                var result = await _api.Get<Response<int>>($"{prefix}masterSwitchStatus");
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
                var toggle = await _api.Get<Response<PiPin>>($"{prefix}toggle?pinType={pinType}");
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

        [Obsolete("This method is not used in the new .net core API")]
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
                var result = await _api.Get<Response<IEnumerable<string>>>($"{prefix}ping");
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
                result = await _api.Get<Response<PiPin>>($"{prefix}status?pinType={pinType}");
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
                var result = await _api.Post<Response<EquipmentSchedule>>($"{prefix}setSchedule", schedule);

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
                    return await _api.Get<Response<EquipmentSchedule>>($"{prefix}getSchedule?scheduleType={scheduleType}");
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
                var result = await _api.Get<Response<LightServerModel>>($"{prefix}getCurrentLightMode?lightType={lightType}");
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
                var result = await _api.Get<Response<LightServerModel>>($"{prefix}saveLightMode?lightMode={mode}&lightType={lightType}");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new LightServerModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PoolSpaModel> GetPool()
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Get<Response<PoolSpaModel>>($"{prefix}get/pool");
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new PoolSpaModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PoolSpaModel> GetSpa()
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Get<Response<PoolSpaModel>>($"{prefix}get/spa");
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new PoolSpaModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<BoosterPumpModel> GetBoosterPump()
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Get<Response<BoosterPumpModel>>($"{prefix}get/booster");
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new BoosterPumpModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HeaterModel> GetHeater()
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Get<Response<HeaterModel>>($"{prefix}get/heater");
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new HeaterModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PoolSpaModel> SavePool(PoolSpaModel poolModel)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Post<Response<PoolSpaModel>>($"{prefix}save/pool", poolModel);
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new PoolSpaModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PoolSpaModel> SaveSpa(PoolSpaModel spaModel)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Post<Response<PoolSpaModel>>($"{prefix}save/spa", spaModel);
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new PoolSpaModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<BoosterPumpModel> SaveBoosterPump(BoosterPumpModel boosterPumpModel)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Post<Response<BoosterPumpModel>>($"{prefix}save/booster", boosterPumpModel);
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new BoosterPumpModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HeaterModel> SaveHeater(HeaterModel heaterModel)
        {
            try
            {
                var result = await Task.Run(async () =>
                {
                    return await _api.Post<Response<HeaterModel>>($"{prefix}save/heater", heaterModel);
                });

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? new HeaterModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
