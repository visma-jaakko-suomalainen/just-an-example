namespace UltimateWorkShiftValidator
{
    
    public class TimeOfDay
    {
        
        public int Hours { get; }
        public int Minutes { get; }


        public TimeOfDay(string time)
        {
            var timeParts = time.Split(":");
            if (timeParts.Length != 2)
            {
                throw new InvalidTimeOfDayException();
            }

            Hours = ParseHours(timeParts[0]);
            Minutes = ParseMinutes(timeParts[1]);
        }

        private static int ParseHours(string time)
        {
            if (!int.TryParse(time, out var hours)) throw new InvalidTimeOfDayException();
            if (hours >= 0 && hours < 24)
            {
                return hours;
            }

            throw new InvalidTimeOfDayException();
        }

        private static int ParseMinutes(string time)
        {
            if (!int.TryParse(time, out var minutes)) throw new InvalidTimeOfDayException();
            if (minutes >= 0 && minutes < 60)
            {
                return minutes;
            }

            throw new InvalidTimeOfDayException();
        }

        public bool IsBefore(TimeOfDay anotherTime)
        {
            if (Hours < anotherTime.Hours)
            {
                return true;
            }

            if (Hours == anotherTime.Hours && Minutes < anotherTime.Minutes)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return Hours.ToString("00") + ":" + Minutes.ToString("00");
        }
    }
}
