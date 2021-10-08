using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingCalendar
{
    struct Task
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
    }
}
