using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eHub.Common.Models;

namespace eHub.Common.Services
{
    public class MockPoolService : IPoolService
    {
        EquipmentSchedule _schedule = new EquipmentSchedule();
        EquipmentSchedule _boosterSchedule = new EquipmentSchedule();
        EquipmentSchedule _poolLightSchedule = new EquipmentSchedule();
        EquipmentSchedule _spaLightSchedule = new EquipmentSchedule();
        EquipmentSchedule _groundLightSchedule = new EquipmentSchedule();
        LightModeType _poolLightMode, _spaLightMode, _previousPoolLightMode, _previousSpaLightMode;
        int _masterSwitchStatus = 0;
        int _includeBoosterStatus = 0;
        Dictionary<PinType, PiPin> _pins;

        public MockPoolService()
        {
            _poolLightMode = LightModeType.NotSet;
            _spaLightMode = LightModeType.NotSet;
            _previousPoolLightMode = LightModeType.NotSet;
            _previousSpaLightMode = LightModeType.NotSet;

            _pins = new Dictionary<PinType, PiPin>
            {
                [PinType.PoolPump] = new PiPin { PinType = PinType.PoolPump, State = 0 },
                [PinType.SpaPump] = new PiPin { PinType = PinType.SpaPump, State = 0 },
                [PinType.BoosterPump] = new PiPin { PinType = PinType.BoosterPump, State = 0 },
                [PinType.Heater] = new PiPin { PinType = PinType.Heater, State = 0 },
                [PinType.PoolLight] = new PiPin { PinType = PinType.PoolLight, State = 0 },
                [PinType.SpaLight] = new PiPin { PinType = PinType.SpaLight, State = 0 },
                [PinType.GroundLights] = new PiPin { PinType = PinType.GroundLights, State = 0 },
            };
        }

        public Task<IEnumerable<PiPin>> GetAllStatuses()
        {
            return Task.FromResult(_pins.Select(_ => _.Value));
        }

        public Task<LightServerModel> GetCurrentLightMode(LightType lightType)
        {
            var model = new LightServerModel();

            switch (lightType)
            {
                case LightType.Pool:
                    model.CurrentMode = _poolLightMode;
                    model.LightType = LightType.Pool;
                    break;
                case LightType.Spa:
                    model.CurrentMode = _spaLightMode;
                    model.LightType = LightType.Spa;
                    break;
            }
            return Task.FromResult(model);
        }

        public Task<int> GetMasterSwitchStatus()
        {
            return Task.FromResult(_masterSwitchStatus);
        }

        public Task<PiPin> GetPinStatus(PinType pinType)
        {
            return Task.FromResult(_pins[pinType]);
        }

        public Task<EquipmentSchedule> GetSchedule(ScheduleType scheduleType)
        {
            switch (scheduleType)
            {
                case ScheduleType.Pool:
                    return Task.FromResult(_schedule);
                case ScheduleType.Booster:
                    return Task.FromResult(_boosterSchedule);
                case ScheduleType.SpaLight:
                    return Task.FromResult(_spaLightSchedule);
                case ScheduleType.PoolLight:
                    return Task.FromResult(_poolLightSchedule);
                default:
                    return Task.FromResult(new EquipmentSchedule());
            }
        }

        public Task<WaterTemp> GetWaterTemp()
        {
            return Task.FromResult(new WaterTemp { ValueC = 28.5, ValueF = 83.3 });
        }

        public Task<bool> Ping()
        {
            return Task.FromResult(true);
        }

        public Task<LightServerModel> SaveLightMode(LightModeType mode, LightType lightType)
        {
            var model = new LightServerModel() {  CurrentMode = mode };
            switch (lightType)
            {
                case LightType.Pool:
                    model.LightType = LightType.Pool;
                    _poolLightMode = mode;
                    break;
                case LightType.Spa:
                    model.LightType = LightType.Spa;
                    _spaLightMode = mode;
                    break;
            }
            return Task.FromResult(model);
        }

        public Task<EquipmentSchedule> SetSchedule(EquipmentSchedule schedule)
        {
            switch (schedule.Type)
            {
                case ScheduleType.Pool:
                    _schedule = schedule;
                    return Task.FromResult(_schedule);
                case ScheduleType.Booster:
                    _boosterSchedule = schedule;
                    return Task.FromResult(_boosterSchedule);
                case ScheduleType.PoolLight:
                    _poolLightSchedule = schedule;
                    return Task.FromResult(_poolLightSchedule);
                case ScheduleType.SpaLight:
                    _spaLightSchedule = schedule;
                    return Task.FromResult(_spaLightSchedule);
                default:
                    return Task.FromResult(new EquipmentSchedule());
            }
        }

        public Task<PiPin> Toggle(PinType pinType)
        {
            _pins[pinType].State = _pins[pinType].State == PinState.ON ? PinState.OFF : PinState.ON;

            if (_pins[pinType].State == PinState.ON)
            {
                _pins[pinType].DateActivated = DateTime.Now;
            }
            return Task.FromResult(_pins[pinType]);
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
