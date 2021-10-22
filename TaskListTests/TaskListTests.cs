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

        // Currently failing, needs some refactoring to fix
        [TestMethod]
        public void TestCompleteTask_WhenTaskExists_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("class");
            taskList.CreateTask("class", "task", 3, DateTime.Now);

            // Act
            var result = taskList.CompleteTask("class", new Task("task", 3, DateTime.Now));

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
            var result = taskList.CompleteTask("class", new Task("task", 3, DateTime.Now));

            // Assert
            Assert.IsFalse(result, "Complete task reported true when task did not exist.");
        }

        [TestMethod]
        public void TestSaveLoadData_WithDefaultPath_Succeeds()
        {
            // Arrange
            var taskList = new TaskList();
            taskList.CreateClass("classA");
            taskList.CreateClass("classB");

            taskList.CreateTask("classA", "taskA", 3, DateTime.Now);

            taskList.CreateReminder(new Task("taskA", 3, DateTime.Now), DateTime.Now);

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

            taskList.CreateReminder(new Task("taskA", 3, DateTime.Now), DateTime.Now);

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

            taskList.CreateReminder(new Task("taskA", 3, DateTime.Now), DateTime.Now);

            // Act, Assert
            Assert.IsFalse(taskList.SaveData("garbage path"), "Save reported success with bad path.");

            // Actually save the data
            Assert.IsTrue(taskList.SaveData());

            Assert.IsFalse(taskList.LoadData("garbage path"), "Load reported success with bad path.");           
        }
    }
}