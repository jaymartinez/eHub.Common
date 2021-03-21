using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public async Task<PiPin> GetStatus(int pin)
        {
            var result = new Response<PiPin>();
            try
            {
                result = await _webApi.Get<Response<PiPin>>($"status?pinNumber={pin}");
            }
            catch (Exception e)
            {
                result.Messages.Add(e.Message);
            }

            HandleMessages(result?.Messages ?? new List<string>());
            return result?.Data ?? null;
        }

        public async Task<IEnumerable<PiPin>> GetAllStatuses()
        {
            var result = new Response<IEnumerable<PiPin>>();

            try
            {
                result = await _webApi.Get<Response<IEnumerable<PiPin>>>("/allStatuses");
            }
            catch (Exception e)
            {
                result.Messages.Add(e.Message);
            }
            
            HandleMessages(result?.Messages ?? new List<string>());
            return result?.Data ?? Enumerable.Empty<PiPin>();
        }

        public async Task<PoolSchedule> SetSchedule(string startTimeStr, string endTimeStr, bool isActive, bool includeBooster)
        {
            var result = await _webApi.Get<Response<PoolSchedule>>(
                $"setSchedule?startDate={startTimeStr}&endDate={endTimeStr}&isActive={isActive}&includeBooster={includeBooster}");

            var msgs = Enumerable.Empty<string>();
            if (result.Messages?.Count > 0)
            {
                msgs = result.Messages;
                Console.WriteLine(">>> Handling Messages from Response.");
                HandleMessages(result.Messages);
            }

            return result?.Data ?? default(PoolSchedule);
        }

        public async Task<bool> Ping()
        {
            try
            {
                var result = await _webApi.Get<Response<IEnumerable<string>>>("ping");
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

        public async Task<PoolSchedule> GetSchedule()
        {
            try
            {
                var result = await _webApi.Get<Response<PoolSchedule>>("getSchedule");
                return result?.Data ?? default(PoolSchedule);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PiPin> Toggle(int pin)
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

            try
            {
                var toggle = await _webApi.Get<Response<PiPin>>(url);
                return toggle.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> ToggleMasterSwitch()
        {
            try
            {
                var result = await _webApi.Get<Response<int>>("toggleMasterSwitch");
                return result.Data;
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
                var result = await _webApi.Get<Response<int>>("toggleIncludeBoosterSwitch");
                return result.Data;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> GetMasterSwitchStatus()
        {
            try
            {
                var result = await _webApi.Get<Response<int>>("masterSwitchStatus");
                return result.Data;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<PoolLightMode> SavePoolLightMode(PoolLightMode mode)
        {
            try
            {
                var result = await _webApi.Get<Response<PoolLightMode>>($"savePoolLightMode?mode={(int)mode}");
                return result.Data;
            }
            catch (Exception)
            {
                return PoolLightMode.NotSet;
            }
        }

        public async Task<PoolLightServerModel> GetCurrentPoolLightMode()
        {
            try
            {
                var result = await _webApi.Get<Response<PoolLightServerModel>>("getPoolLightMode");
                return result.Data;
            }
            catch (Exception)
            {
                return new PoolLightServerModel
                {
                    CurrentMode = (int)PoolLightMode.NotSet,
                    PreviousMode = (int)PoolLightMode.NotSet
                };
            }
        }
    }
}
