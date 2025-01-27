using BlazorTaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTaskManager.Database
{
    public class TaskContext : DbContext
    {
        // Read connection string

        protected readonly IConfiguration Configuration;

        public TaskContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Connect to database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("TabDB"));
        }

        public DbSet<TaskItem> TaskItem { get; set; }
    }
}

