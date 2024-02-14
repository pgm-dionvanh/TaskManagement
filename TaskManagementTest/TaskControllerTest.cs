using Microsoft.Extensions.Logging;
using TaskManagement.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;


namespace TaskManagementTest
{
    public class TaskManagementTest
    {
        private readonly ILogger<TasksController> _logger;

        public TaskManagementTest()
        {
            _logger = new Mock<ILogger<TasksController>>().Object;
        }

        [Fact]
        public void GetTasks_ReturnsAllTasks()
        {
            // Create new controller
            var controller = new TasksController(_logger);

            // Get Tasks
            var result = controller.GetTasks();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<TaskManagement.Task>>>(result);
        }

        [Fact]
        public void CreateTask_AddsNewTask()
        {
            // Create new controller
            var controller = new TasksController(_logger);

            // Mock task
            var newTask = new TaskManagement.Task { Id = 4, Name = "Task 4", Description = "Description for Task 4", DueDate = "2024-02-17" };

            var result = controller.CreateTask(newTask) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public void DeleteTask_DeletesTask()
        {
            // Create new controller
            var controller = new TasksController(_logger);

            // Delete task
            var deleteTask = controller.DeleteTask(1);


            // Assert
            Assert.NotNull(deleteTask);
            Assert.IsType<OkResult>(deleteTask);
        }

        [Fact]
        public void UpdateTask_UpdatesTask()
        {
            // Create new controller
            var controller = new TasksController(_logger);

            // Mock UpdatedTask
            var updatedTask = new TaskManagement.Task();

            // Change data 
            updatedTask.Id = 1;
            updatedTask.Name = "Mock";
            updatedTask.Description = "Mock test task";
            updatedTask.DueDate = "Now";

            //Update task
            var updateTask = controller.UpdateTask(1, updatedTask);

            //Assert

            Assert.NotNull(updateTask);
            Assert.IsType<OkObjectResult>(updateTask);
        }
    }
}