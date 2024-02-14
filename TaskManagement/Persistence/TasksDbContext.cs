using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TaskManagement.Persistence
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options): base(options)
        {

        }

        public DbSet<Task> Task { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                DotNetEnv.Env.Load(); // Load .env file
                string connectionString = DotNetEnv.Env.GetString("DB_CONNECTION_STRING");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}
