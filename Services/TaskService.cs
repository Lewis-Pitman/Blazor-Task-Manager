using BlazorTaskManager.Database;
using BlazorTaskManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlazorTaskManager.Services
{
    public class TaskService
    {
        private IDbContextFactory<TabContext> _dbContextFactory;

        public TaskService(IDbContextFactory<TabContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<TaskItem> GetTaskAsync(Guid taskId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.TaskItem.FirstOrDefaultAsync(item => item.Id == taskId);
            }
        }

        public async Task<List<TaskItem>> GetAllTasksWithTabIdAsync(Guid tabId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.TaskItem.Where(task => task.TabId == tabId).ToListAsync();
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

        public void EditTask(Guid taskToEdit, TaskItem task)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var existingTask = context.TaskItem.Find(taskToEdit);

                if (existingTask != null)
                {
                    existingTask.Title = task.Title;
                    existingTask.Description = task.Description;
                    existingTask.Status = task.Status;
                    existingTask.DueDate = task.DueDate;

                    context.SaveChanges();
                }
            }
        }

        public void RemoveTask(TaskItem task)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.TaskItem.Remove(task);
                context.SaveChanges();
            }
        }

        public void RemoveAllTasksWithTabId(Guid tabId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var tasksToRemove = context.TaskItem.Where(task => task.TabId == tabId).ToList();

                foreach (var task in tasksToRemove)
                {
                    context.TaskItem.Remove(task);
                }

                context.SaveChanges();
            }
        }

        // Search
        public async  Task<List<TaskItem>> GetTaskWithStatusAsync(string status)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.TaskItem.Where(item => item.Status == status).ToListAsync();
            }
        }

        public async  Task<List<TaskItem>> GetTaskWithTitleAsync(string title)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.TaskItem.Where(item => item.Title == title).ToListAsync();
            }
        }

        
        public async  Task<List<TaskItem>> GetTaskByDateAsync(DateTime dateTime, Guid tabId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.TaskItem.Where(item => item.DueDate == dateTime && item.TabId == tabId).ToListAsync();
            }
        }
        
    }
}
