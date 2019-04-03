using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock.Grimaldi
{
    /// <summary>
    /// ClockBuilder models the BerlinClock, the main responsability is to build it
    /// </summary>
    public class ClockBuilder
    {
        public Clock Build(string sTime)
        {
            var layerClock = new List<Floor>();
            layerClock.Add(GetTopOfTheClock());
            layerClock.Add(GetTopHours());
            layerClock.Add(GetBottomHours());
            layerClock.Add(GetTopMinutes());
            layerClock.Add(GetBottomMinutes());
            return new Clock(layerClock, sTime);
        }
        
        private Floor GetTopOfTheClock()
        {
            return new Floor(new List<ILamp> { new TwoSecondLamp() });
        }

        private Floor GetTopHours()
        {
            return new Floor(new List<ILamp>
            {
                new FiveHoursLamp(),
                new FiveHoursLamp(),
                new FiveHoursLamp(),
                new FiveHoursLamp()
            });
        }
        private Floor GetBottomHours()
        {
            return new Floor(new List<ILamp>
            {
                new OneHourLamp(),
                new OneHourLamp(),
                new OneHourLamp(),
                new OneHourLamp()
            });
        }

        private Floor GetTopMinutes()
        {
            return new Floor(new List<ILamp>
            {
                new FiveMinutesLamp(),
                new FiveMinutesLamp(),
                new QuarterLamp(),

                new FiveMinutesLamp(),
                new FiveMinutesLamp(),
                new QuarterLamp(),

                new FiveMinutesLamp(),
                new FiveMinutesLamp(),
                new QuarterLamp(),

                new FiveMinutesLamp(),
                new FiveMinutesLamp()
            });
        }

        private Floor GetBottomMinutes()
        {
            return new Floor(new List<ILamp>
            {
                new OneMinuteLamp(),
                new OneMinuteLamp(),
                new OneMinuteLamp(),
                new OneMinuteLamp()
            });
        }
    }

    public class Floor
    {
        public List<ILamp> Lamps;
        public Floor(List<ILamp> lamps)
        {
            Lamps = lamps;
        }

        public override string ToString() => string.Join(string.Empty, Lamps.Select(lamp => lamp.ToString()));
    }
}
