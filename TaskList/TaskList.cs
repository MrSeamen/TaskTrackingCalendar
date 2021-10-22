using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TaskTrackingCalendar
{
    public class TaskList
    {
        private Dictionary<string, List<Task>> tasks;

        private List<Reminder> reminders;

        private List<Task> completedTasks;

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

        public bool UpdateTask(string aClass, Task task, string name = "", int priority = -1, DateTime date = default)
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
                    //check reminders
                    foreach(Reminder r in reminders)
                    {
                        //if task is in a reminder
                        if (r.GetTask() == task)
                        {
                            reminders.Remove(r);
                            break;
                        }
                    }
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
            if (reminders.Contains(new Reminder(task, time)))
            {
                return false;
            } else
            {
                reminders.Add(new Reminder(task, time));
                return true;
            }
        }

        public bool UpdateReminder(Reminder reminder, string taskName = "", DateTime date = default)
        {
            // only update reminder with a given val if it is not equal to the defined default value
            // need to look up the task with the given taskName, if one is given
            //if reminders contains reminder
            if (reminders.Contains(reminder))
            {
                if (!(reminder.GetTask().GetName() == "" && date == default))
                {
                    reminders.Add(new Reminder(new Task(taskName, reminder.GetTask().GetPriority(), reminder.GetTask().GetDate()), date));
                    reminders.Remove(reminder);
                    return true;
                } else {
                    return false;
                }
            }
            // else
            else {
                //return false
                return false;
            }
        }

        public bool DeleteReminder(Reminder reminder)
        {
            if (reminders.Contains(reminder))
            {
                reminders.Remove(reminder);
                return true;
            } else {
                return false;
            }
        }

        public bool CompleteTask(string aClass, Task task)
        {
            List<Task> list;
            if (tasks.TryGetValue(aClass, out list))
            {
                if (list.Contains(task))
                {
                    // Remove any reminders related to the task
                    foreach (Reminder r in reminders)
                    {
                        if (r.GetTask() == task)
                        {
                            reminders.Remove(r);
                        }
                    }

                    //update class's tasklist
                    tasks.Remove(aClass, out list);
                    list.Remove(task);
                    tasks.Add(aClass, list);

                    completedTasks.Add(task);

                    return true;
                }
                // Can't complete a task that doesn't exist
                return false;
            }
            // Can't complete a task in a class that doesn't exist
            return false;
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

        public bool SaveData(string path = "")
        {
            var fileName = "SavedData.txt";
            // Figure out file path - if not default, we're not gonna mess with what they're telling us
            var filePath = Path.Combine(path, fileName);
            if (path == "")
            {
                // Generate default path
                var dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskTrackingCalendar");
                Directory.CreateDirectory(dirPath);

                filePath = Path.Combine(dirPath, fileName);
            }

            // Serialize data
            var data = new List<string>();
            foreach (string key in tasks.Keys)
            {
                data.Add("CLASS " + key);
                var list = new List<Task>();
                if (tasks.TryGetValue(key, out list))
                {
                    foreach (Task task in list)
                    {
                        data.Add("TASK " + key + " " + task.GetName() + " " + task.GetPriority() + " " + task.GetDate().ToString());
                    }
                } else
                {
                    // it dont work
                    return false;
                }
            }
            foreach (Reminder rem in reminders)
            {
                data.Add("REMINDER " + rem.GetTask().GetName() + " " + rem.GetTime().ToString());
            }

            // Write data to file
            try
            {
                File.WriteAllLines(filePath, data);

            } catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool LoadData(string path = "")
        {
            var fileName = "SavedData.txt";
            // Figure out file path - if not default, we're not gonna mess with what they're telling us
            var filePath = Path.Combine(path, fileName);
            if (path == "")
            {
                var dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskTrackingCalendar");

                filePath = Path.Combine(dirPath, fileName);
            }

            // Read data from file
            string[] lines;
            try
            {
                lines = File.ReadAllLines(filePath);

            } catch (Exception)
            {
                return false;
            }

            // Deserialize data
            tasks = new Dictionary<string, List<Task>>();
            reminders = new List<Reminder>();
            foreach (string s in lines)
            {
                var arr = s.Split(" ");
                switch (arr[0])
                {
                    case "CLASS":
                        tasks.Add(arr[1], new List<Task>());
                        break;
                    case "TASK":
                        List<Task> list;
                        if (tasks.TryGetValue(arr[1], out list))
                        {
                            list.Add(new Task(arr[2], int.Parse(arr[3]), DateTime.Parse(arr[4])));
                        } else
                        {
                            // ooh it dont work right
                        }
                        break;
                    case "REMINDER":
                        Task t = findTask(arr[1]);
                        reminders.Add(new Reminder(t, DateTime.Parse(arr[2])));
                        break;
                    default:
                        break;
                }

            }

            return true;
        }

        public Task findTask(string name)
        {
            foreach(List<Task> l in tasks.Values)
            {
                foreach(Task t in l)
                {
                    if (t.GetName() == name)
                    {
                        return t;
                    }
                }
            }
            throw new ArgumentException("task doesn't exist");
        }
    }
}
