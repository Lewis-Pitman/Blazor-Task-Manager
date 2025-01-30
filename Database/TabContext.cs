using BlazorTaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTaskManager.Database
{
    public class TabContext : DbContext
    {
        // Read connection string

        protected readonly IConfiguration Configuration;

        public TabContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Connect to database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("TabDB"));
        }

        public DbSet<TabView> Tabs { get; set; }
        public DbSet<TaskItem> TaskItem { get; set; }
    }
}
