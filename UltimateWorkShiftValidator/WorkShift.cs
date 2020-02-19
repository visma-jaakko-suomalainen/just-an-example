using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateWorkShiftValidator
{
    public class WorkShift : IWorkShift
    {
        private const decimal MaximumLengthOfWorkShift = 16;

        private readonly DateTime m_date;
        private readonly TimeSpan m_timeSpan;

        public WorkShift(DateTime date, string startTime, string endTime)
        {
            m_date = date;
            m_timeSpan = new TimeSpan(new TimeOfDay(startTime), new TimeOfDay(endTime));

            if (m_timeSpan.GetLength() > MaximumLengthOfWorkShift)
            {
                throw new WorkShiftTooLongException();
            }
        }

        public decimal Length()
        {
            return m_timeSpan.GetLength();
        }

        public override string ToString()
        {
            return m_date.ToShortDateString() + " " + m_timeSpan;
        }

    }
}