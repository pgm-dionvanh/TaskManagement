using Microsoft.Extensions.Logging;
using TaskManagement.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;


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
    }
}