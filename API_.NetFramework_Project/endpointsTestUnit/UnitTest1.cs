using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using API_.NetFramework_Project.Controllers;
using API_.NetFramework_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace endpointsTestUnit
{
    [TestClass]
    public class TaskControllerTests
    {
        private TaskController _controller;

        [TestInitialize]
        public void Setup()
        {
            // Create a new instance of the TaskController for each test.
            _controller = new TaskController();
        }

        //[TestMethod]
        //public void Test_GetTitle_ReturnsOk()
        //{
        //    // Arrange: No additional setup is needed.

        //    // Act: Call the GetTitle action method.
        //    var result = _controller.GetTitle(1);

        //    // Assert: Check if the response is an OK status code (200).
        //    Assert.IsInstanceOfType(result, typeof(ActionResult<string>));
        //    var okResult = (ActionResult<string>)result;
        //    Assert.IsInstanceOfType(okResult.Result, typeof(OkObjectResult));
        //    var objectResult = (OkObjectResult)okResult.Result;
        //    Assert.AreEqual(200, objectResult.StatusCode);

        //    // Now, you can access the value directly from the objectResult if needed.
        //    var title = (string)objectResult.Value;

        //    // Perform additional assertions as needed.
        //    Assert.AreEqual("Expected Title", title); // Replace "Expected Title" with the expected value.
        //}



        //[TestMethod]
        //public void Test_GetIsCompleted_ReturnsOk()
        //{
        //    // Arrange: No additional setup is needed.

        //    // Act: Call the GetIsCompleted action method.
        //    var result = _controller.GetIsCompleted(1);

        //    // Assert: Check if the response is an OK status code (200).
        //    Assert.IsInstanceOfType(result, typeof(ActionResult<bool>));
        //    var okResult = (ActionResult<bool>)result;
        //    Assert.IsInstanceOfType(okResult.Result, typeof(OkObjectResult));
        //    var objectResult = (OkObjectResult)okResult.Result;
        //    Assert.AreEqual(200, objectResult.StatusCode);

        //    // Now, you can access the value directly from the objectResult if needed.
        //    var isCompleted = (bool)objectResult.Value;

        //    // Perform additional assertions as needed.
        //    Assert.AreEqual(true, isCompleted); // Replace with your expected value.
        //}


        //[TestMethod]
        //public void Test_CreateTask_ReturnsCreatedAtAction()
        //{
        //    // Arrange: Create a new TaskTp instance for testing.
        //    var newTask = new TaskTp { Id = 3, Title = "Test Task", IsCompleted = false };

        //    // Act: Call the CreateTask action method.
        //    var result = _controller.CreateTask(newTask);

        //    // Assert: Check if the response is an OK status code (201).
        //    Assert.IsInstanceOfType(result, typeof(ActionResult<TaskTp>));
        //    var okResult = (ActionResult<TaskTp>)result;
        //    Assert.IsInstanceOfType(okResult.Result, typeof(OkObjectResult));
        //    var objectResult = (OkObjectResult)okResult.Result;
        //    Assert.AreEqual(201, objectResult.StatusCode);

        //    // Now, you can access the created task directly from the objectResult if needed.
        //    var createdTask = (TaskTp)objectResult.Value;

        //    // Perform additional assertions as needed.
        //    Assert.AreEqual(newTask, createdTask); // Replace with your expected value.
        //}

        [TestMethod]
        public void Test_GetTask_ExistingId_ReturnsOk()
        {
            // Arrange: No additional setup is needed.

            // Act: Call the GetTask action method for an existing task.
            var result = _controller.GetTask(1);

            // Assert: Check if the response is an OK status code (200).
            Assert.IsInstanceOfType(result, typeof(ActionResult<TaskTp>));
            var okResult = (ActionResult<TaskTp>)result;
            Assert.IsInstanceOfType(okResult.Result, typeof(OkObjectResult));
            var objectResult = (OkObjectResult)okResult.Result;
            Assert.AreEqual(200, objectResult.StatusCode);

            // Now, you can access the task directly from the objectResult if needed.
            var task = (TaskTp)objectResult.Value;

            // Perform additional assertions as needed.
            Assert.AreEqual(1, task.Id); // Replace with your expected value.
        }

        [TestMethod]
        public void Test_GetTask_NonExistingId_ReturnsNotFound()
        {
            // Arrange: No additional setup is needed.

            // Act: Call the GetTask action method for a non-existing task.
            var result = _controller.GetTask(999);

            // Assert: Check if the response is a Not Found status code (404).
            Assert.IsInstanceOfType(result, typeof(ActionResult<TaskTp>));
            var actionResult = (ActionResult<TaskTp>)result;
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
            var notFoundResult = (NotFoundResult)actionResult.Result;
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }


        [TestMethod]
        public void Test_GetCompletedTasks_ReturnsOk()
        {
            // Arrange: No additional setup is needed.

            // Act: Call the GetCompletedTasks action method.
            var result = _controller.GetCompletedTasks();

            // Assert: Check if the response is an OK status code (200).
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<TaskTp>>));
            var okResult = (ActionResult<IEnumerable<TaskTp>>)result;
            Assert.IsInstanceOfType(okResult.Result, typeof(OkObjectResult));
            var objectResult = (OkObjectResult)okResult.Result;
            Assert.AreEqual(200, objectResult.StatusCode);

            // Now, you can access the list of completed tasks directly from the objectResult if needed.
            var completedTasks = (IEnumerable<TaskTp>)objectResult.Value;

            // Perform additional assertions as needed.
            // Example: Assert.IsTrue(completedTasks.Any()); // Check if there are completed tasks.
        }

        [TestMethod]
        public void Test_GetIncompleteTasks_ReturnsOk()
        {
            // Arrange: No additional setup is needed.

            // Act: Call the GetIncompleteTasks action method.
            var result = _controller.GetIncompleteTasks();

            // Assert: Check if the response is an OK status code (200).
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<TaskTp>>));
            var okResult = (ActionResult<IEnumerable<TaskTp>>)result;
            Assert.IsInstanceOfType(okResult.Result, typeof(OkObjectResult));
            var objectResult = (OkObjectResult)okResult.Result;
            Assert.AreEqual(200, objectResult.StatusCode);

            // Now, you can access the list of incomplete tasks directly from the objectResult if needed.
            var incompleteTasks = (IEnumerable<TaskTp>)objectResult.Value;

            // Perform additional assertions as needed.
            // Example: Assert.IsTrue(incompleteTasks.Any()); // Check if there are incomplete tasks.
        }

    }
}
