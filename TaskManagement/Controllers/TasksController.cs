﻿using Microsoft.AspNetCore.Mvc;
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
            new Task { Id = 1, Title = "Task 1", Description = "Description for Task 1", DueDate = "2024-02-14" },
            new Task { Id = 2, Title = "Task 2", Description = "Description for Task 2", DueDate = "2024-02-15" },
            new Task { Id = 3, Title = "Task 3", Description = "Description for Task 3", DueDate = "2024-02-16" }
        };

        // GET: api/tasks
        [HttpGet(Name = "GetTasks")]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            /* Return all tasks */
            return _tasks;
        }

        // Delete: api/tasks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            /* Find task by id */
            var taskToRemove = _tasks.SingleOrDefault(t => t.Id == id);

           /* if task not found */
           if(taskToRemove == null) return NotFound();



           /* Remove task */
           _tasks.Remove(taskToRemove);


            /* Return 200 ok status code */
            return Ok();
        }
    }
}
