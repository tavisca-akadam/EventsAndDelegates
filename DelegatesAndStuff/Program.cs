using System;

namespace DelegatesAndStuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Worker worker = new Worker();

            //Using Tradiition Way
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);
            worker.DoWork(10, WorkType.GoToMeeting);
            worker.WorkPerformed -= Worker_WorkPerformed;                               //TO remove the event from invocation list
            worker.WorkCompleted -= Worker_WorkCompleted;

            //Using Delegate Inference 
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.DoWork(8, WorkType.GenerateReport);
            worker.WorkPerformed -= Worker_WorkPerformed;                              //TO remove the event from invocation list
            worker.WorkCompleted -= Worker_WorkCompleted;

            //Using Ananumous Method
            worker.WorkPerformed += delegate(object sender, WorkPerformedEventArgs e) {
                Console.WriteLine($"number of hours {e.Hours}, by work {e.WorkType} and owner was {sender.ToString()}");
            };

            worker.WorkCompleted += delegate(object sender, EventArgs e) {
                Console.WriteLine("Work Done");
            };

            //Using Lambdas
            var worker1 = new Worker();

            worker1.WorkPerformed += (s, e) => Console.WriteLine($"number of hours {e.Hours}, by work {e.WorkType} and owner was {s.ToString()}");
            worker1.WorkCompleted += (s, e) => Console.WriteLine("Work Done");

            worker1.DoWork(4, WorkType.GoToMeeting);
            worker.DoWork(6, WorkType.PlayCricket);

            Console.ReadKey(true);
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work done");
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"number of hours {e.Hours}, by work {e.WorkType} and owner was {sender.ToString()}");
        }

        public enum WorkType
        {
            PlayCricket,
            GoToMeeting,
            GenerateReport
        }
    }
}
