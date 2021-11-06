using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingCalendar
{
    public class Task
    {
        private string name { get; set; }
        private string className { get; set; }
        private int priority { get; set; }
        private DateTime date { get; set; }

        public Task(string name, string className, int priority, DateTime date)
        {
            this.name = name;
            this.className = className;
            this.priority = priority;
            this.date = date.Date;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetClassName()
        {
            return className;
        }

        public void SetClassName(string className)
        {
            this.className = className;
        }

        public int GetPriority()
        {
            return priority;
        }

        public void SetPriority(int priority)
        {
            this.priority = priority;
        }

        public DateTime GetDate()
        {
            return date;
        }

        public void SetDate(DateTime date)
        {
            this.date = date;
        }

        public override bool Equals(object obj)
        {
            return obj is Task task &&
                   name == task.name &&
                   priority == task.priority &&
                   date == task.date;
        }
    }
}
