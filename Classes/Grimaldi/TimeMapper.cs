using System;
using System.Collections.Generic;

namespace BerlinClock.Grimaldi
{
    public enum TimeUnity { Hour, Second, Minute };

    /// <summary>
    /// Time Manager is useful to parse the string and create a static mapping 
    /// </summary>
    public class TimerManager
    {
        private Dictionary<TimeUnity, int> _mapping;
        private int hour;
        private int minute;
        private int second;

        public TimerManager(string sTime)
        {
            ParseTime(sTime);
            CreateMapping();
        }

        public void ParseTime(string sTime) {
            // used split insted of DateTime.TryParse to manage the difference between 00:00:00 and 24:00:00
            if (string.IsNullOrWhiteSpace(sTime))
                throw new ArgumentException("the time format is not correct, please use HH:mm:ss");

            var time = sTime.Split(':');

            if (time.Length < 3)
                throw new ArgumentException("the time format is not correct, please use HH:mm:ss");

            int.TryParse(time[0], out hour);
            if (hour > 24 || hour < 0)
                throw new ArgumentException("the hour should be between 0 and 24");

            int.TryParse(time[1], out minute);
            if (minute > 59 || hour < 0)
                throw new ArgumentException("the minute should be between 0 and 24");

            int.TryParse(time[2], out second);
            if (minute > 59 || hour < 0)
                throw new ArgumentException("the second should be between 0 and 24");

            if(hour == 24 && (minute != 0 || second!=0))
                throw new ArgumentException("the time is nor valid");
        }

        public void CreateMapping() {
            _mapping = new Dictionary<TimeUnity, int>() {
                { TimeUnity.Hour,  hour},
                { TimeUnity.Minute, minute },
                { TimeUnity.Second, second }
            };
        }

        public void Update(int valueToDecrease, TimeUnity unity) {
            _mapping[unity] -= valueToDecrease;
        }
        public int GetTimeByType(TimeUnity type)
        {
            return _mapping[type];
        }
    }
}
