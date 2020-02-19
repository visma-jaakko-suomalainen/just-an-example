using System;

namespace UltimateWorkShiftValidator
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                IWorkShift workShift = new WorkShift(new DateTime(2020, 02, 18), "08:00", "16:20");

                Console.WriteLine("Work shift");
                Console.WriteLine(workShift.ToString());
                Console.WriteLine("Length of the work shift: " + workShift.Length());

            }
            catch (InvalidTimeOfDayException)
            {
                Console.WriteLine("The given time is invalid");
            }
            catch (InvalidTimeSpanException)
            {
                Console.WriteLine("The time span is invalid");
            }
            catch (WorkShiftTooLongException)
            {
                Console.WriteLine("Work shift is too long");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception: " + e);
            }

        }
    }
}