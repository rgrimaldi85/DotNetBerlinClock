using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock.Grimaldi
{
    public class Clock {
        private readonly List<Floor> _layerClock;
        private readonly TimerManager _timeMapper;

        public Clock(List<Floor> layerClock, string sTime)
        {
            _layerClock = layerClock;
            _timeMapper = new TimerManager(sTime);
            _layerClock.ForEach(layer => {
                TurnOnLamps(layer);
            });
        }

        private TimerManager TurnOnLamps(Floor layer)
        {
            layer.Lamps.ForEach(lamp =>
            {
                if (lamp.Switch(_timeMapper))
                    _timeMapper.Update(lamp.GetValue(), lamp.GetTimeUnity());
            });
            return _timeMapper;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _layerClock.Select(lamp => lamp.ToString()));
        }
    }
}
