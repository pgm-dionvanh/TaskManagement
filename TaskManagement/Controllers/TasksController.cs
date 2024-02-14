using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;

        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        /* Todo write crud */

        //Task list
        private static List<Task> _tasks = new List<Task>
        {
            new Task { Id = 1, Name = "Task 1", Description = "Description for Task 1", DueDate = "2024-02-14" },
            new Task { Id = 2, Name = "Task 2", Description = "Description for Task 2", DueDate = "2024-02-15" },
            new Task { Id = 3, Name = "Task 3", Description = "Description for Task 3", DueDate = "2024-02-16" }
        };

        // GET: api/tasks
        [HttpGet(Name = "GetTasks")]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            /* Return all tasks */
            return _tasks;
        }

        // Delete: api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            /* Find task by id */
            var taskToRemove = _tasks.SingleOrDefault(t => t.Id == id);

           /* If task not found */
           if(taskToRemove == null) return NotFound();


           /* Remove task */
           _tasks.Remove(taskToRemove);


            /* Return 200 ok status code */
            return Ok();
        }

        // Put: api/tasks/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Task updatedTask)
        {
            /* Find task by id */
            var taskToUpdate = _tasks.SingleOrDefault(_task => _task.Id == id);
            
            /* If task not found */
            if(taskToUpdate == null) return NotFound();

            /* Update task */
            taskToUpdate.Name = updatedTask.Name;
            taskToUpdate.Description = updatedTask.Description;
            taskToUpdate.DueDate = updatedTask.DueDate;


            /* Return 200 updated task */
            return Ok(taskToUpdate);
        }

        // Post: api/task
        public ActionResult<Task> CreateTask(Task newTask)
        {
            newTask.Id = _tasks.Count() + 1; /* Count how many task there are then increment with 1 to increment id */

            /* Save new task */
            _tasks.Add(newTask);


            /* Return createdAtAction with task */
            return CreatedAtAction(nameof(GetTasks), new { id = newTask.Id }, newTask);
        }
    }
}
