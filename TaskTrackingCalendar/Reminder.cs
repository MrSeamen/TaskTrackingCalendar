using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingCalendar
{
    struct Reminder
    {
        private Task task { get; set; }
        private DateTime time { get; set; }

        public Reminder(Task task, DateTime time)
        {
            this.task = task;
            this.time = time;
        }
    }
}
