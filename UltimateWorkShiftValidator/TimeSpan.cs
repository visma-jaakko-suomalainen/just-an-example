using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateWorkShiftValidator
{
    public class TimeSpan
    {
        private const int HourInMinutes = 60;

        private TimeOfDay m_start;
        private TimeOfDay m_end;

        public TimeSpan(TimeOfDay start, TimeOfDay end)
        {
            if (end.IsBefore(start))
            {
                throw new InvalidTimeSpanException();
            }

            this.m_start = start;
            this.m_end = end;
        }

        public decimal GetLength()
        {
            decimal hours = m_end.Hours - m_start.Hours;
            decimal minutes = m_end.Minutes - m_start.Minutes;

            return hours + (minutes / HourInMinutes);
        }

        public override string ToString()
        {
            return m_start + " - " + m_end;
        }
    }
}