using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingCalendar
{
    public class TaskList
    {
        private Dictionary<string, List<Task>> tasks;

        private List<Reminder> reminders;

        public TaskList()
        {
            tasks = new Dictionary<string, List<Task>>();
            reminders = new List<Reminder>();
        }

        public bool CreateClass(string name)
        {
            if (tasks.ContainsKey(name))
            {
                // An academic class with the same name already exists, so this one can't be created
                return false;
            }

            tasks.Add(name, new List<Task>());
            return true;
        }

        public bool UpdateClass(string aClass, string newName)
        {
            List<Task> list;
            if (tasks.TryGetValue(aClass, out list))
            {
                if (tasks.ContainsKey(newName))
                {
                    //Can't do the update, another class already has the new name
                    return false;
                }
                tasks.Remove(aClass);
                tasks.Add(newName, list);
                return true;
            }

            // No class with the given name existed, so it can't be updated
            return false;
        }

        public bool DeleteClass(string aClass)
        {
            if (tasks.ContainsKey(aClass))
            {
                tasks.Remove(aClass);
                return true;
            }

            // No class with the given name existed, so it can't be deleted
            return false;
        }

        public bool CreateTask(string aClass, string name, int priority, DateTime date)
        {
            List<Task> list;
            //checks if class key exists for task list
            if (tasks.TryGetValue(aClass, out list))
            {
                //if task name exists within academic class's task list
                foreach (Task t in list)
                {
                    if (t.GetName().Equals(name))
                    {
                        //return false
                        return false;
                    }
                }
                //else make new task under academic class
                tasks[aClass].Add(new Task(name, priority, date));
                return true;
            }
            //class doesn't exist, can't create task in academic class's task list
            return false;
        }

        public bool UpdateTask(string aClass, Task task, string name, int priority, DateTime date)
        {
            List<Task> list;
            //check if task exists within class key's task list
            if (tasks.TryGetValue(aClass, out list))
            {
                foreach(Task t in list)
                {
                    if (t.Equals(task)) //unsure if this is the proper way to compare tasks
                    {
                        // only update task with a given val if it is not equal to the defined default values: name = "", priority = -1, date = default
                        if (!(t.GetName().Equals("") || t.GetPriority() == -1 || t.GetDate().Equals(default))) 
                        {
                            tasks.Remove(aClass, out list);
                            list.Remove(task);
                            list.Add(new Task(name, priority, date));
                            tasks.Add(aClass, list);
                            return true;
                        } else
                        {
                            //target task only has default values
                            return false;
                        }
                    }
                }
                //task does not exist within task list
                return false;
            }
            //Class does not exist, cannot update task
            return false;
        }

        public bool DeleteTask(string aClass, Task task)
        {
            List<Task> list;
            if (tasks.TryGetValue(aClass, out list))
            {
                if (list.Contains(task))
                {
                    //update class's tasklist
                    tasks.Remove(aClass, out list);
                    list.Remove(task);
                    tasks.Add(aClass, list);
                    return true;
                }
                //Academic class doesn't contain task in its task list
                return false;
            }
            //specified class does not exist
            return false;
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
