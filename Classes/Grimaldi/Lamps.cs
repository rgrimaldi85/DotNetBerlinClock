namespace BerlinClock.Grimaldi
{
    public enum ColorLight { R, Y }

    public interface ILamp
    {
        bool Switch(TimerManager timeMapper);
        string ToString();

        int GetValue();
        TimeUnity GetTimeUnity();
    }

    /// <summary>
    /// Generic Base Lamp
    /// </summary>
    public class Lamp : ILamp
    {
        internal bool _isOn = false;
        private readonly ColorLight _colorLight;

        private int _value;
        private TimeUnity _timeUnity;


        public Lamp(int value, ColorLight colorLight, TimeUnity timeUnity)
        {
            _value = value;
            _colorLight = colorLight;
            _timeUnity = timeUnity;
        }

        public virtual bool Switch(TimerManager timeMapper)
        {
            _isOn = timeMapper.GetTimeByType(_timeUnity) >= _value;
            return _isOn;
        }

        public override string ToString()
        {
            if (_isOn)
                return _colorLight.ToString();
            return "O";
        }

        public int GetValue()
        {
            return _value;
        }

        public TimeUnity GetTimeUnity()
        {
            return _timeUnity;
        }
    }

    /// <summary>
    /// Derived classes
    /// I could take just one class (the base and move this logic in the ClockBuilder)
    /// I prefer to have more classes than a long list of parameters in my constructor 
    /// with the dependecy injection I could use specific interface to inject all 
    /// </summary>
    public class QuarterLamp : Lamp
    {
        public QuarterLamp() : base(5, ColorLight.R, TimeUnity.Minute)
        {
        }
    }

    public class FiveMinutesLamp : Lamp
    {
        public FiveMinutesLamp() : base(5, ColorLight.Y, TimeUnity.Minute)
        {
        }
    }

    public class FiveHoursLamp : Lamp
    {
        public FiveHoursLamp() : base(5, ColorLight.R, TimeUnity.Hour)
        {
        }
    }

    public class OneHourLamp : Lamp
    {
        public OneHourLamp() : base(1, ColorLight.R, TimeUnity.Hour)
        {
        }
    }

    public class OneMinuteLamp : Lamp
    {
        public OneMinuteLamp() : base(1, ColorLight.Y, TimeUnity.Minute)
        {
        }
    }

    public class TwoSecondLamp : Lamp
    {
        public TwoSecondLamp() : base(2, ColorLight.Y, TimeUnity.Second)
        {
        }

        // yellow lamp that blinks on/off every two seconds.
        public override bool Switch(TimerManager timeMapper)
        {
            if (timeMapper.GetTimeByType(GetTimeUnity()) == 0)
            {
                _isOn = true;
                return _isOn;
            }
            
                _isOn = (timeMapper.GetTimeByType(GetTimeUnity()) % GetValue() == 0);
            return _isOn;
        }
    }
}
