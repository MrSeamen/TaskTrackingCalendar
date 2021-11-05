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
            completedTasks = new List<Task>();
        }

        public Task FindTask(string className, string taskName)
        {
            List<Task> list;
            if (tasks.TryGetValue(className, out list)) {
                foreach (Task t in list)
                {
                    if (t.GetName() == taskName)
                    {
                        return t;
                    }
                }
            }
            throw new ArgumentException("Task does not exist");
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
            // If the class doesn't exist, return false
            if (!tasks.ContainsKey(aClass))
            {
                return false;
            }

            // If a task with the name already exists, return false
            try
            {
                FindTask(aClass, name);
                // If no exception was thrown, a task with the name already exists
                return false;
            } catch (ArgumentException)
            {
                // Go ahead and create the task
                tasks[aClass].Add(new Task(name, priority, date));
                return true;
            }
        }

        public bool UpdateTask(string aClass, string taskName, string name = "", int priority = -1, DateTime date = default)
        {
            // If the class doesn't exist, return false
            if (!tasks.ContainsKey(aClass))
            {
                return false;
            }

            // Confirm that the task exists
            Task t;
            try
            {
                t = FindTask(aClass, taskName);
            }
            catch (ArgumentException)
            {
                // The task didn't exist to update
                return false;
            }

            // Update the task
            if (name != "")
            {
                t.SetName(name);
            }
            if (priority != -1)
            {
                t.SetPriority(priority);
            }
            if (!date.Equals(default))
            {
                t.SetDate(date);
            }
            return true;
        }

        public bool DeleteTask(string aClass, string taskName)
        {
            // If the class doesn't exist, return false
            if (!tasks.ContainsKey(aClass))
            {
                return false;
            }

            // Confirm that the task exists
            Task t;
            try
            {
                t = FindTask(aClass, taskName);
            }
            catch (ArgumentException)
            {
                // The task didn't exist to delete
                return false;
            }

            return tasks[aClass].Remove(t);
        }

        public bool CreateReminder(string aClass, string taskName, DateTime time)
        {
            // If the class doesn't exist, return false
            if (!tasks.ContainsKey(aClass))
            {
                return false;
            }

            try
            {
                FindTask(aClass, taskName);
            } catch (ArgumentException)
            {
                // Task doesn't exist
                return false;
            }

            foreach (var r in reminders)
            {
                if (r.GetClassName() == aClass && r.GetTaskName() == taskName)
                {
                    // The task already has a reminder
                    return false;
                }
            }

            reminders.Add(new Reminder(aClass, taskName, time));
            return true;
        }

        public bool UpdateReminder(string className, string taskName, DateTime date)
        {
            foreach (var r in reminders)
            {
                if (r.GetClassName() == className && r.GetTaskName() == taskName)
                {
                    // This is our reminder!
                    r.SetTime(date);
                    return true;
                }
            }

            // Reminder didn't exist to update
            return false;
        }

        public bool DeleteReminder(string className, string taskName)
        {
            foreach (var r in reminders)
            {
                if (r.GetClassName() == className && r.GetTaskName() == taskName)
                {
                    // This is our reminder!
                    reminders.Remove(r);
                    return true;
                }
            }

            // Reminder didn't exist to remove
            return false;
        }

        public bool CompleteTask(string aClass, string taskName)
        {
            // If the class doesn't exist, return false
            if (!tasks.ContainsKey(aClass))
            {
                return false;
            }

            // Check that the task exists
            Task t;
            try
            {
                t = FindTask(aClass, taskName);
            } catch (ArgumentException)
            {
                // Task doesn't exist to complete
                return false;
            }

            // Remove any related reminders
            foreach (Reminder r in reminders)
            {
                if (r.GetClassName() == aClass && r.GetTaskName() == taskName)
                {
                    reminders.Remove(r);
                }
            }

            // Add task to completed tasks, remove from task list
            completedTasks.Add(t);
            tasks[aClass].Remove(t);
            return true;
        }

        public (List<Task>, List<Reminder>) SummaryData(bool sortPriority = true, string sortClassName = "")
        {
            List<Task> taskList = new List<Task>();
            List<Reminder> reminderList = new List<Reminder>();
            // if sortClassName is provided, need to look up that class
            if (!sortClassName.Equals(""))
            {
                if (tasks.TryGetValue(sortClassName, out taskList))
                {
                    if (sortPriority == true)
                    {
                        List<Task> sortedList = selectionSort(taskList);
                        taskList.Clear();
                        taskList.AddRange(sortedList);
                    }
                } //else class doesn't exist, list data is empty
            } else //not sorting for a specific class
            {
                if (tasks.Values.Any())
                {
                    foreach (List<Task> t in tasks.Values)
                    {
                        taskList.AddRange(t);
                    }
                    if (sortPriority == true)
                    {
                        List<Task> sortedList = selectionSort(taskList);
                        taskList.Clear();
                        taskList.AddRange(sortedList);
                    }
                } //else empty data, list data will be empty
            }
            //reminders will be in the right order no matter what because tasklist will be sorted or not based on user designation
            if (reminders.Any())
            {
                foreach (Reminder r in reminders)
                {
                    foreach (Task t in taskList)
                    {
                        if (t.GetName() == r.GetTaskName())
                        {
                            reminderList.Add(r);
                        }
                    }
                }
            }
            return (taskList, reminderList);
        }

        //helper method for Summary Data
        public List<Task> selectionSort(List<Task> taskList)
        {
            List<Task> workingList = new List<Task>(taskList);
            //selection sort O(n^2)
            for (int i = 0; i < workingList.Capacity; i++)
            {
                int maxPosition = -1;
                for (int j = 0; j < workingList.Capacity; j++)
                {
                    if (workingList[i].GetPriority() > workingList[j].GetPriority())
                    {
                        maxPosition = j;
                    }
                }
                Task current = new Task(workingList[i].GetName(), workingList[i].GetPriority(), workingList[i].GetDate());
                Task destinationTask = new Task(workingList[maxPosition].GetName(), workingList[maxPosition].GetPriority(), workingList[maxPosition].GetDate());
                workingList[maxPosition] = current;
                workingList[i] = destinationTask;
            }
            return workingList;
        }

        public List<Task> CalendarData(int month = -1)
        {
            if (month == -1)
            {
                month = DateTime.Now.Month;
            }
            List<Task> taskList = new List<Task>();
            if (tasks.Values.Any())
            {
                foreach (List<Task> l in tasks.Values)
                {
                    foreach (Task t in l)
                    {
                        if (t.GetDate().Month.Equals(month))
                        {
                            taskList.Add(t);
                        }
                    }
                }
            }
            return taskList;
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
                data.Add("REMINDER " + rem.GetClassName() + " " + rem.GetTaskName() + " " + rem.GetTime().ToString());
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
                        }
                        break;
                    case "REMINDER":
                        reminders.Add(new Reminder(arr[1], arr[2], DateTime.Parse(arr[3])));
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
