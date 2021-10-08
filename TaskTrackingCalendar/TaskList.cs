using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingCalendar
{
    class TaskList
    {
        private Dictionary<AcademicClass, List<Task>> tasks;

        private List<Reminder> reminders;

        public TaskList()
        {
            tasks = new Dictionary<AcademicClass, List<Task>>();
            reminders = new List<Reminder>();
        }

        public bool CreateClass(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateClass(AcademicClass aClass, string name)
        {
            throw new NotImplementedException();
        }

        public bool DeleteClass(AcademicClass aClass)
        {
            throw new NotImplementedException();
        }

        public bool CreateTask(string name, int priority, DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTask(Task task, string name = "", int priority = -1, DateTime date = default)
        {
            // only update task with a given val if it is not equal to the defined default value
            throw new NotImplementedException();
        }

        public bool DeleteTask(Task task)
        {
            throw new NotImplementedException();
        }

        public bool CreateReminder(Task task, DateTime time)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReminder(Reminder reminder, string taskName = "", DateTime date = default)
        {
            // only update reminder with a given val if it is not equal to the defined default value
            // need to look up the task with the given taskName, if one is given
            throw new NotImplementedException();
        }

        public bool DeleteReminder(Reminder reminder)
        {
            throw new NotImplementedException();
        }

        public bool CompleteTask(Task task)
        {
            throw new NotImplementedException();
        }

        public (List<Task>, List<Reminder>) SummaryData(bool sortPriority = true, string sortClassName = "")
        {
            // if sortClassName is provided, need to look up that class
            throw new NotImplementedException();
        }

        public List<Task> CalendarData(int month = -1)
        {
            if (month == -1)
            {
                month = DateTime.Now.Month;
            }
            throw new NotImplementedException();
        }

        public bool SaveData(string path = "some default path")
        {
            throw new NotImplementedException();
        }

        public bool LoadData(string path = "some default path")
        {
            throw new NotImplementedException();
        }
    }
}
