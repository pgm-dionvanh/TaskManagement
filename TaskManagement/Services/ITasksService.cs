using TaskManagement.Models;
using ErrorOr;

namespace TaskManagement.Services
{
    public interface ITasksService
    {
        ErrorOr<Created> CreateTask(Task task);
    }
}
