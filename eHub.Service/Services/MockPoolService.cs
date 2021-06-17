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
        EquipmentSchedule _poolLightSchedule = new EquipmentSchedule();
        EquipmentSchedule _spaLightSchedule = new EquipmentSchedule();
        EquipmentSchedule _groundLightSchedule = new EquipmentSchedule();
        PoolLightMode _poolLightMode, _spaLightMode, _previousPoolLightMode, _previousSpaLightMode;
        int _masterSwitchStatus = 0;
        int _includeBoosterStatus = 0;
        Dictionary<int, PiPin> _pins;

        public MockPoolService()
        {
            _poolLightMode = PoolLightMode.NotSet;
            _spaLightMode = PoolLightMode.NotSet;
            _previousPoolLightMode = PoolLightMode.NotSet;
            _previousSpaLightMode = PoolLightMode.NotSet;

            _pins = new Dictionary<int, PiPin>
            {
                [5] = new PiPin { PinNumber = 5, State = 0 },
                [6] = new PiPin { PinNumber = 6, State = 0 },
                [12] = new PiPin { PinNumber = 12, State = 0 },
                [13] = new PiPin { PinNumber = 13, State = 0 },
                [23] = new PiPin { PinNumber = 23, State = 0 },
                [24] = new PiPin { PinNumber = 24, State = 0 },
                [17] = new PiPin { PinNumber = 17, State = 0 },
                [19] = new PiPin { PinNumber = 19, State = 0 },
                [20] = new PiPin { PinNumber = 20, State = 0 },
                [21] = new PiPin { PinNumber = 21, State = 0 }
            };
        }

        public Task<IEnumerable<PiPin>> GetAllStatuses()
        {
            return Task.FromResult(_pins.Select(_ => _.Value));
        }

        public Task<PoolLightServerModel> GetCurrentPoolLightMode()
        {
            var model = new PoolLightServerModel()
            {
                CurrentMode = (int)_poolLightMode,
                PreviousMode = (int)_previousPoolLightMode
            };
            return Task.FromResult(model);
        }

        public Task<PoolLightServerModel> GetCurrentSpaLightMode()
        {
            var model = new PoolLightServerModel()
            {
                CurrentMode = (int)_spaLightMode,
                PreviousMode = (int)_previousSpaLightMode
            };
            return Task.FromResult(model);
        }

        public Task<EquipmentSchedule> GetGroundLightSchedule()
        {
            return Task.FromResult(_groundLightSchedule);
        }

        public Task<int> GetMasterSwitchStatus()
        {
            return Task.FromResult(_masterSwitchStatus);
        }

        public Task<PiPin> GetPinStatus(int pin)
        {
            return Task.FromResult(_pins[pin]);
        }

        public Task<EquipmentSchedule> GetPoolLightSchedule()
        {
            return Task.FromResult(_poolLightSchedule);
        }

        public Task<PoolSchedule> GetSchedule()
        {
            return Task.FromResult(_schedule);
        }

        public Task<EquipmentSchedule> GetSpaLightSchedule()
        {
            return Task.FromResult(_spaLightSchedule);
        }

        public Task<WaterTemp> GetWaterTemp()
        {
            return Task.FromResult(new WaterTemp { ValueC = 28.5, ValueF = 83.3 });
        }

        public Task<bool> Ping()
        {
            return Task.FromResult(true);
        }

        public Task<PoolLightMode> SavePoolLightMode(PoolLightMode mode)
        {
            _poolLightMode = mode;
            return Task.FromResult(mode);
        }

        public Task<PoolLightMode> SaveSpaLightMode(PoolLightMode mode)
        {
            _spaLightMode = mode;
            return Task.FromResult(mode);
        }

        public Task<EquipmentSchedule> SetGroundLightSchedule(DateTime startTime, DateTime endTime, bool isActive)
        {
            _groundLightSchedule = new EquipmentSchedule();
            _groundLightSchedule.StartHour = startTime.Hour;
            _groundLightSchedule.StartMinute = startTime.Minute;
            _groundLightSchedule.EndHour = endTime.Hour;
            _groundLightSchedule.EndMinute = endTime.Minute;

            return Task.FromResult(_groundLightSchedule);
        }

        public Task<EquipmentSchedule> SetPoolLightSchedule(DateTime startTime, DateTime endTime, bool isActive)
        {
            _poolLightSchedule = new EquipmentSchedule();
            _poolLightSchedule.StartHour = startTime.Hour;
            _poolLightSchedule.StartMinute = startTime.Minute;
            _poolLightSchedule.EndHour = endTime.Hour;
            _poolLightSchedule.EndMinute = endTime.Minute;

            return Task.FromResult(_poolLightSchedule);
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

        public Task<EquipmentSchedule> SetSpaLightSchedule(DateTime startTime, DateTime endTime, bool isActive)
        {
            var sched = new EquipmentSchedule();
            sched.StartHour = startTime.Hour;
            sched.StartMinute = startTime.Minute;
            sched.EndHour = endTime.Hour;
            sched.EndMinute = endTime.Minute;

            return Task.FromResult(sched);
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
