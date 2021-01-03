using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eHub.Common.Models;

namespace eHub.Common.Services
{
    public class MockPoolService : IPoolService
    {
        PoolSchedule _schedule = new PoolSchedule();
        int _masterSwitchStatus = 0;
        int _includeBoosterStatus = 0;
        Dictionary<int, PiPin> _pins;

        public MockPoolService()
        {
            _pins = new Dictionary<int, PiPin>
            {
                [5] = new PiPin { PinNumber = 5, State = 0 },
                [6] = new PiPin { PinNumber = 6, State = 0 },
                [13] = new PiPin { PinNumber = 13, State = 0 },
                [17] = new PiPin { PinNumber = 17, State = 0 },
                [19] = new PiPin { PinNumber = 19, State = 0 },
                [20] = new PiPin { PinNumber = 20, State = 0 },
                [21] = new PiPin { PinNumber = 21, State = 0 }
            };
        }

        public Task<IEnumerable<PiPin>> GetAllStatuses()
        {
            return Task.FromResult(Enumerable.Empty<PiPin>());
        }

        public Task<int> GetMasterSwitchStatus()
        {
            return Task.FromResult(_masterSwitchStatus);
        }

        public Task<PiPin> GetPinStatus(int pin)
        {
            return Task.FromResult(_pins[pin]);
        }

        public Task<PoolSchedule> GetSchedule()
        {
            return Task.FromResult(_schedule);
        }

        public Task<bool> Ping()
        {
            return Task.FromResult(true);
        }

        public Task<PoolSchedule> SetSchedule(DateTime startTime, DateTime endTime, bool isActive, bool includeBooster)
        {
            _schedule.StartHour = startTime.Hour;
            _schedule.StartMinute = startTime.Minute;
            _schedule.EndHour = endTime.Hour;
            _schedule.EndMinute = endTime.Minute;
            _schedule.IsActive = isActive;
            _schedule.IncludeBooster = includeBooster;

            return Task.FromResult(_schedule);
        }

        public Task<PiPin> Toggle(int pin)
        {
            _pins[pin].State = _pins[pin].State == PinState.ON ? PinState.OFF : PinState.ON;

            if (_pins[pin].State == PinState.ON)
            {
                _pins[pin].DateActivated = DateTime.Now;
            }
            return Task.FromResult(_pins[pin]);
        }

        public Task<int> ToggleIncludeBoosterSwitch()
        {
            _includeBoosterStatus = _includeBoosterStatus == 1 ? 0 : 1;
            return Task.FromResult(_includeBoosterStatus);
        }

        public Task<int> ToggleMasterSwitch()
        {
            _masterSwitchStatus = _masterSwitchStatus == 1 ? 0 : 1;
            return Task.FromResult(_masterSwitchStatus);
        }
    }
}
