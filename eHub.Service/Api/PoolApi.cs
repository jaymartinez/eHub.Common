﻿using System;
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

        public async Task<PiPin> GetStatus(EquipmentType pin)
        {
            Response<PiPin> result = null;
            try
            {
                result = await _webApi.Get<Response<PiPin>>($"status?pinNumber={(int)pin}");
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

        public async Task<PoolSchedule> SetSchedule(string startTimeStr, string endTimeStr)
        {
            var result = await _webApi.Get<Response<PoolSchedule>>(
                $"setSchedule?startDate={startTimeStr}&endDate={endTimeStr}");

            var msgs = Enumerable.Empty<string>();
            if (result.Messages?.Count > 0)
            {
                msgs = result.Messages;
                Console.WriteLine(">>> Handling Messages from Response.");
                HandleMessages(result.Messages);
            }

            return result.Data;
        }

        public async Task<IEnumerable<string>> Ping()
        {
            var result = await _webApi.Get<Response<IEnumerable<string>>>("ping");
            return result.Messages ?? Enumerable.Empty<string>();
        }

        public async Task<PoolSchedule> GetSchedule()
        {
            var result = await _webApi.Get<Response<PoolSchedule>>("getSchedule");
            return result.Data;
        }

        public async Task<PiPin> Toggle(EquipmentType pin)
        {
            var url = string.Empty;

            switch (pin)
            {
                case EquipmentType.PoolPump:
                    url = "poolPump";
                    break;
                case EquipmentType.Heater:
                    url = "heater";
                    break;
                case EquipmentType.SpaLight:
                    url = "spaLight";
                    break;
                case EquipmentType.SpaPump:
                    url = "spaPump";
                    break;
                case EquipmentType.BoosterPump:
                    url = "boosterPump";
                    break;
            }

            var toggle = await _webApi.Get<PiPin>(url);
            return toggle;
        }
    }
}
