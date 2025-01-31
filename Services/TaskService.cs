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
                    // Add due date

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
        public List<TaskItem> GetTaskWithStatus(string status)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.TaskItem.Where(item => item.Status == status).ToList();
            }
        }

        public List<TaskItem> GetTaskWithTitle(string title)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.TaskItem.Where(item => item.Title == title).ToList();
            }
        }

        
        public List<TaskItem> GetTaskByDate(DateTime dateTime)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.TaskItem.Where(item => item.DueDate == dateTime).ToList();
            }
        }
        
    }
}
