using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskTrackingCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingCalendar.Tests
{
    [TestClass()]
    public class TaskListTests
    {
        [TestMethod]
        public void TestCreateClass_WhenDataValid_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();

            // Act
            var result = taskList.CreateClass("test class name");

            // Assert
            Assert.IsTrue(result, "Could not successfully create a class.");
        }

        [TestMethod]
        public void TestCreateClass_WhenDataInvalid_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("test class name");

            // Act
            var result = taskList.CreateClass("test class name");

            // Assert
            Assert.IsFalse(result, "Created a class with a name that was taken.");
        }

        [TestMethod]
        public void TestUpdateClass_WhenAllowed_Succeeds()
        {
            // Arrange
            var name = "test class name";
            var newName = "new test class name";

            var taskList = new TaskList();
            taskList.CreateClass(name);

            // Act
            var updateResult = taskList.UpdateClass(name, newName);

            // Check that the name was changed by checking that you aren't allowed to create a class with the new name
            var newCreateResult = taskList.CreateClass(newName);

            // Assert
            Assert.IsTrue(updateResult, "Could not update a class name.");
            Assert.IsFalse(newCreateResult, "Incorrectly updated a class name.");
        }

        [TestMethod]
        public void TestUpdateClass_WhenNoClass_Fails()
        {
            // Arrange
            var taskList = new TaskList();

            // Act
            var result = taskList.UpdateClass("some name", "some new name");

            // Assert
            Assert.IsFalse(result, "Updated a class that did not exist.");
        }

        [TestMethod]
        public void TestUpdateClass_WhenNameConflict_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("classA");
            taskList.CreateClass("classB");

            // Act
            var result = taskList.UpdateClass("classA", "classB");

            // Assert
            Assert.IsFalse(result, "Updated a class when the new name was not valid");
        }

        [TestMethod]
        public void TestDeleteClass_WhenClassExists_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("classA");

            // Act
            var result = taskList.DeleteClass("classA");

            // Assert
            Assert.IsTrue(result, "Could not delete a class.");
        }

        [TestMethod]
        public void TestDeleteClass_WhenNoClass_Fails()
        {
            // Arrange
            var taskList = new TaskList();

            // Act
            var result = taskList.DeleteClass("classA");

            // Assert
            Assert.IsFalse(result, "Deleted a class that did not exist.");
        }

        [TestMethod]
        public void TestCreateTask_WhenValid_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");

            // Act
            var result = taskList.CreateTask("class", "task", 2, DateTime.Now);

            // Assert
            Assert.IsTrue(result, "Couldn't create task.");
        }

        [TestMethod]
        public void TestCreateTask_WhenInvalid_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");

            // Act
            var result1 = taskList.CreateTask("class", "task", 2, DateTime.Now);
            var result2 = taskList.CreateTask("class", "task", 2, DateTime.Now);

            // Assert
            Assert.IsTrue(result1, "Couldn't create task.");
            Assert.IsFalse(result2, "Created two tasks with same name.");
        }

        [TestMethod]
        public void TestUpdateTask_WhenValid_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 2, DateTime.Now);

            // Act
            var result = taskList.UpdateTask("class", "task", "newname", 3, DateTime.Now);

            // Assert
            Assert.IsTrue(result, "Couldn't update task.");
        }

        [TestMethod]
        public void TestUpdateTask_WhenInvalid_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");

            // Act
            var result = taskList.UpdateTask("class", "task", "newname", 3, DateTime.Now);

            // Assert
            Assert.IsFalse(result, "Updated task that didn't exist.");
        }

        [TestMethod]
        public void TestDeleteTask_WhenValid_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 2, DateTime.Now);

            // Act
            var result = taskList.DeleteTask("class", "task");

            // Assert
            Assert.IsTrue(result, "Couldn't delete task.");
        }

        [TestMethod]
        public void TestDeleteTask_WhenInvalid_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");

            // Act
            var result = taskList.DeleteTask("class", "task");

            // Assert
            Assert.IsFalse(result, "Deleted task that didn't exist.");
        }

        [TestMethod]
        public void TestCreateReminder_WhenValid_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 2, DateTime.Now);

            // Act
            var result = taskList.CreateReminder("class", "task", DateTime.Now);

            // Assert
            Assert.IsTrue(result, "Couldn't create reminder.");
        }

        [TestMethod]
        public void TestCreateReminder_WhenInvalid_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 2, DateTime.Now);

            // Act
            DateTime time = DateTime.Now;
            var result1 = taskList.CreateReminder("class", "task", time);
            var result2 = taskList.CreateReminder("class", "task", time);

            // Assert
            Assert.IsTrue(result1, "Couldn't create reminder.");
            Assert.IsFalse(result2, "Created duplicate reminder.");
        }

        [TestMethod]
        public void TestUpdateReminder_WhenValid_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 2, DateTime.Now);
            taskList.CreateReminder("class", "task", DateTime.Now);

            // Act
            var result = taskList.UpdateReminder("class", "task", DateTime.Now);

            // Assert
            Assert.IsTrue(result, "Could not update reminder.");
        }

        [TestMethod]
        public void TestUpdateReminder_WhenInvalid_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 2, DateTime.Now);

            // Act
            var result = taskList.UpdateReminder("class", "task", DateTime.Now);

            // Assert
            Assert.IsFalse(result, "Updated reminder that doesn't exist.");
        }

        [TestMethod]
        public void TestDeleteReminder_WhenValid_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 2, DateTime.Now);
            taskList.CreateReminder("class", "task", DateTime.Now);

            // Act
            var result = taskList.DeleteReminder("class", "task");

            // Assert
            Assert.IsTrue(result, "Could not delete reminder.");
        }

        [TestMethod]
        public void TestDeleteReminder_WhenInvalid_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 2, DateTime.Now);

            // Act
            var result = taskList.DeleteReminder("class", "task");

            // Assert
            Assert.IsFalse(result, "Deleted reminder that didn't exist.");
        }

        // Currently failing, needs some refactoring to fix
        [TestMethod]
        public void TestCompleteTask_WhenTaskExists_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 3, DateTime.Now);

            // Act
            var result = taskList.CompleteTask("class", "task");

            // Assert
            Assert.IsTrue(result, "Complete task failed.");

        }

        [TestMethod]
        public void TestCompleteTask_WhenNoTask_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");

            // Act
            var result = taskList.CompleteTask("class", "task");

            // Assert
            Assert.IsFalse(result, "Complete task reported true when task did not exist.");
        }

        [TestMethod]
        public void TestSummaryData_WhenNotSorted_WithClass()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("ClassA");
            taskList.CreateTask("ClassA", "HW1", 2, default);
            taskList.CreateTask("ClassA", "HW2", 1, default);
            taskList.CreateClass("ClassB");
            taskList.CreateTask("ClassB", "Project", 2, default);
            taskList.CreateTask("ClassB", "Exam", 3, default);
            taskList.CreateReminder("ClassB", "Project", taskList.findTask("Project").GetDate());
            taskList.CreateReminder("ClassB", "Exam", taskList.findTask("Exam").GetDate());

            List<Task> tasks = new List<Task>() { new Task("HW1", 2, default), new Task("HW2", 1, default) };
            List<Reminder> reminders = new List<Reminder>();

            // Act
            var result = taskList.SummaryData(false, "ClassA");

            // Assert
            CollectionAssert.AreEqual(result.Item1, tasks);
            CollectionAssert.AreEqual(result.Item2, reminders);
        }

        [TestMethod] 
        public void TestSummaryData_NoClass()
        {
            // Arrange
            var taskList = new TaskList();

            // Act
            var result = taskList.SummaryData();

            // Assert
            CollectionAssert.AreEqual(result.Item1, new List<Task>());
            CollectionAssert.AreEqual(result.Item2, new List<Reminder>());
        }

        [TestMethod]
        public void TestCalendarData_NoValues()
        {
            // Arrange
            var taskList = new TaskList();

            // Act, Assert
            CollectionAssert.AreEqual(taskList.CalendarData(), new List<Task>());
        }

        [TestMethod]
        public void TestSaveLoadData_WithDefaultPath_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("classA");
            taskList.CreateClass("classB");

            taskList.CreateTask("classA", "taskA", 3, DateTime.Now);

            taskList.CreateReminder("ClassA", "taskA", DateTime.Now);

            // Act
            taskList.SaveData();

            // Assert
            Assert.IsTrue(taskList.DeleteClass("classA"));
            Assert.IsTrue(taskList.DeleteClass("classB"));

            Assert.IsFalse(taskList.DeleteClass("classA"));
            Assert.IsFalse(taskList.DeleteClass("classB"));

            // Act
            taskList.LoadData();

            // Assert
            Assert.IsTrue(taskList.DeleteClass("classA"));
            Assert.IsTrue(taskList.DeleteClass("classB"));
        }

        [TestMethod]
        public void TestSaveLoadData_WhenPathValid_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("classA");
            taskList.CreateClass("classB");

            taskList.CreateTask("classA", "taskA", 3, DateTime.Now);

            taskList.CreateReminder("ClassA", "taskA", DateTime.Now);

            // Act
            Assert.IsTrue(taskList.SaveData(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)),
                "Save failed.");

            // Assert
            Assert.IsTrue(taskList.DeleteClass("classA"));
            Assert.IsTrue(taskList.DeleteClass("classB"));

            Assert.IsFalse(taskList.DeleteClass("classA"));
            Assert.IsFalse(taskList.DeleteClass("classB"));

            // Act
            Assert.IsTrue(taskList.LoadData(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)),
                "Load failed.");

            // Assert
            Assert.IsTrue(taskList.DeleteClass("classA"));
            Assert.IsTrue(taskList.DeleteClass("classB"));
        }

        [TestMethod]
        public void TestSaveLoadData_WhenPathInvalid_Fails()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("classA");
            taskList.CreateClass("classB");

            taskList.CreateTask("classA", "taskA", 3, DateTime.Now);

            taskList.CreateReminder("classA", "taskA", DateTime.Now);

            // Act, Assert
            Assert.IsFalse(taskList.SaveData("garbage path"), "Save reported success with bad path.");

            // Actually save the data
            Assert.IsTrue(taskList.SaveData());

            Assert.IsFalse(taskList.LoadData("garbage path"), "Load reported success with bad path.");           
        }
    }
}