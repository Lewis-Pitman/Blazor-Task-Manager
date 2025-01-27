using BlazorTaskManager.Database;
using BlazorTaskManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlazorTaskManager.Services
{
    public class TaskService
    {
        private IDbContextFactory<TaskContext> _dbContextFactory;

        public TaskService(IDbContextFactory<TaskContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public TaskItem GetTask(Guid taskId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.TaskItem.FirstOrDefault(item => item.Id == taskId);
            }
        }

        public List<TaskItem> GetAllTasksWithTabId(Guid tabId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.TaskItem.Where(task => task.TabId == tabId).ToList();
            }
        }

        public List<TaskItem> GetTaskWithStatus(string status)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.TaskItem.Where(item => item.Status == status).ToList();
            }
        }

        public void AddTask(TaskItem task)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                context.TaskItem.Add(task);
                context.SaveChanges();
            }
        }
    }
}
