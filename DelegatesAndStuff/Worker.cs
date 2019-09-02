using System;
using System.Collections.Generic;
using System.Text;
using static DelegatesAndStuff.Program;

namespace DelegatesAndStuff
{
    // public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

    public class Worker
    {
        //public event WorkPerformedHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public virtual void DoWork(int hours, WorkType workType)
        {
            for(int i = 0; i < hours; i++)
            {
                //Do work here
                OnWorkPerformed(i + 1, workType);
            }
            //After work completion
            OnWorkCompleted();
        }

        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if(del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, workType));
            }
        }
    }
}
