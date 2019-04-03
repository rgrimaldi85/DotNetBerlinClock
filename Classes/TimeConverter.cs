using BerlinClock.Grimaldi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var builder = new ClockBuilder();
            var result = builder.Build(aTime).ToString();
            return result;
        }
    }
}
