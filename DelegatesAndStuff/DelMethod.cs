using System;
using static DelegatesAndStuff.Program;

namespace DelegatesAndStuff
{
    public class DelMethod
    {
        public static void WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"number of hours {e.Hours}, by work {e.WorkType} and owner was {sender.ToString()}");
        }

        public static void WorkDone(object sender, EventArgs e)
        {
            Console.WriteLine("Work done");
        }
    }
}
