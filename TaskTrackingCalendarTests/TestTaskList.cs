using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskList;

namespace TaskTrackingCalendarTests
{
    [TestClass]
    public class TestTaskList
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
    }
}
