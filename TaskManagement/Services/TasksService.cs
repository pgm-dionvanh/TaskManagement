using TaskManagement.Models;
using ErrorOr;


namespace TaskManagement.Services
{
    public class TasksService
    {
        private static readonly Dictionary<Guid, TaskManagement.Models.Task> _tasks = new();

        public ErrorOr<Created>  CreateTask(TaskManagement.Models.Task task)
        {
            _tasks.Add(task.Id, task);

            return Result.Created;
        }
    }
}
