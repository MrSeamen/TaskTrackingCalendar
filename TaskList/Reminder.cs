using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingCalendar
{
    public class Reminder
    {
        private string className;
        private string taskName;
        private DateTime time;

        public Reminder(string className, string taskName, DateTime time)
        {
            this.className = className;
            this.taskName = taskName;
            this.time = time;
        }

        public string GetClassName()
        {
            return className;
        }

        public void SetClassName(string className)
        {
            this.className = className;
        }

        public string GetTaskName()
        {
            return taskName;
        }

        public void SetTaskName(string taskName)
        {
            this.taskName = taskName;
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
