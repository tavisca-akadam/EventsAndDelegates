using System;

namespace DelegatesAndStuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Worker worker = new Worker();
            worker.WorkPerformed += DelMethod.WorkPerformed;
            worker.WorkCompleted += DelMethod.WorkDone;

            worker.DoWork(10, WorkType.GoToMeeting);
            Console.ReadKey(true);
        }

        public enum WorkType
        {
            PlayCricket,
            GoToMeeting,
            GenerateReport
        }
    }
}
