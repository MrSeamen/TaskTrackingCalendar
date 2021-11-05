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
        private int priority { get; set; }
        private DateTime date { get; set; }

        public Task(string name, int priority, DateTime date)
        {
            this.name = name;
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
