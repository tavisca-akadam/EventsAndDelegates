using System;

namespace DelegatesAndStuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Worker worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(DelMethod.WorkPerformed);
            worker.WorkCompleted += new EventHandler(DelMethod.WorkDone);

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
