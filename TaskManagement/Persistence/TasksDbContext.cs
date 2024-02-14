using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Persistence
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options): base(options)
        {

        }

        public DbSet<Task> Task { get; set; } = null!;
    }
}
