using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingCalendar
{
    public class Reminder
    {
        private Task task;
        private DateTime time;

        public Reminder(Task task, DateTime time)
        {
            this.task = task;
            this.time = time;
        }

        public Task GetTask()
        {
            return task;
        }

        public void SetTask(Task task)
        {
            this.task = task;
        }

        public DateTime GetTime()
        {
            return time;
        }

        public void SetTime(DateTime time)
        {
            this.time = time;
        }
    }
}
