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
                var result = await _api.Get<Response<IEnumerable<PiPin>>>("/allStatuses");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? Enumerable.Empty<PiPin>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PiPin> GetPinStatus(int pin)
        {
            var result = new Response<PiPin>();
            try
            {
                result = await _api.Get<Response<PiPin>>($"status?pinNumber={pin}");
            }
            catch (Exception e)
            {
                result.Messages.Add(e.Message);
            }

            HandleMessages(result?.Messages ?? new List<string>());

            return result?.Data ?? null;
        }

        public async Task<PoolSchedule> GetSchedule()
        {
            try
            {
                var result = await _api.Get<Response<PoolSchedule>>("getSchedule");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
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

        public async Task<PoolSchedule> SetSchedule(DateTime startTime, DateTime endTime, bool isActive, bool includeBooster)
        {
            try
            {
                string startDateStr = startTime.ToString(@"MM\/dd\/yyyy HH:mm");
                string endDateStr = endTime.ToString(@"MM\/dd\/yyyy HH:mm");

                var result = await _api.Get<Response<PoolSchedule>>(
                    $"setSchedule?startDate={startDateStr}&endDate={endDateStr}&isActive={isActive}&includeBooster={includeBooster}");

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EquipmentSchedule> GetGroundLightSchedule()
        {
            try
            {
                var result = await _api.Get<Response<PoolSchedule>>("getGroundLightSchedule");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EquipmentSchedule> SetGroundLightSchedule(DateTime startTime, DateTime endTime, bool isActive)
        {
            try
            {
                string startDateStr = startTime.ToString(@"MM\/dd\/yyyy HH:mm");
                string endDateStr = endTime.ToString(@"MM\/dd\/yyyy HH:mm");

                var result = await _api.Get<Response<EquipmentSchedule>>(
                    $"setGroundLightSchedule?startDate={startDateStr}&endDate={endDateStr}&isActive={isActive}");

                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EquipmentSchedule> GetPoolLightSchedule()
        {
            try
            {
                var result = await _api.Get<Response<EquipmentSchedule>>("getPoolLightSchedule");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EquipmentSchedule> SetPoolLightSchedule(DateTime startTime, DateTime endTime, bool isActive)
        {
            try
            {
                string startDateStr = startTime.ToString(@"MM\/dd\/yyyy HH:mm");
                string endDateStr = endTime.ToString(@"MM\/dd\/yyyy HH:mm");

                var result = await _api.Get<Response<EquipmentSchedule>>(
                $"setPoolLightSchedule?startDate={startDateStr}&endDate={endDateStr}&isActive={isActive}");

                if (result.Messages?.Count > 0)
                {
                    HandleMessages(result.Messages);
                }

                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EquipmentSchedule> GetSpaLightSchedule()
        {
            try
            {
                var result = await _api.Get<Response<EquipmentSchedule>>("getSpaLightSchedule");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EquipmentSchedule> SetSpaLightSchedule(DateTime startTime, DateTime endTime, bool isActive)
        {
            try
            {
                string startDateStr = startTime.ToString(@"MM\/dd\/yyyy HH:mm");
                string endDateStr = endTime.ToString(@"MM\/dd\/yyyy HH:mm");

                var result = await _api.Get<Response<EquipmentSchedule>>(
                $"setSpaLightSchedule?startDate={startDateStr}&endDate={endDateStr}&isActive={isActive}");

                if (result.Messages?.Count > 0)
                {
                    HandleMessages(result.Messages);
                }

                return result?.Data ?? default;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PiPin> Toggle(int pin)
        {
            try
            {
                var url = string.Empty;
                switch (pin)
                {
                    case Pin.PoolPump:
                        url = "poolPump";
                        break;
                    case Pin.Heater:
                        url = "heater";
                        break;
                    case Pin.SpaLight:
                        url = "spaLight";
                        break;
                    case Pin.SpaPump:
                        url = "spaPump";
                        break;
                    case Pin.BoosterPump:
                        url = "boosterPump";
                        break;
                    case Pin.PoolLight:
                        url = "poolLight";
                        break;
                    case Pin.GroundLights:
                        url = "groundLights";
                        break;
                }

                var toggle = await _api.Get<Response<PiPin>>(url);
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

        public async Task<PoolLightServerModel> GetCurrentPoolLightMode()
        {
            try
            {
                var defaultModel = new PoolLightServerModel
                {
                    CurrentMode = (int)PoolLightMode.NotSet,
                    PreviousMode = (int)PoolLightMode.NotSet
                };

                var result = await _api.Get<Response<PoolLightServerModel>>("getPoolLightMode");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? defaultModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PoolLightMode> SavePoolLightMode(PoolLightMode mode)
        {
            try
            {
                var result = await _api.Get<Response<PoolLightMode>>($"savePoolLightMode?mode={(int)mode}");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? PoolLightMode.NotSet;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PoolLightServerModel> GetCurrentSpaLightMode()
        {
            try
            {
                var defaultModel = new PoolLightServerModel
                {
                    CurrentMode = (int)PoolLightMode.NotSet,
                    PreviousMode = (int)PoolLightMode.NotSet
                };

                var result = await _api.Get<Response<PoolLightServerModel>>("getSpaLightMode");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? defaultModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PoolLightMode> SaveSpaLightMode(PoolLightMode mode)
        {
            try
            {
                var result = await _api.Get<Response<PoolLightMode>>($"saveSpaLightMode?mode={(int)mode}");
                HandleMessages(result?.Messages ?? new List<string>());
                return result?.Data ?? PoolLightMode.NotSet;
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
    }
}
