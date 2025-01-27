using BlazorTaskManager.Database;
using BlazorTaskManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlazorTaskManager.Services
{
    public class TabService
    {

        private IDbContextFactory<TabContext> _dbContextFactory;

        public TabService(IDbContextFactory<TabContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public List<TabView> GetAllTabs()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Tabs.ToList();
            }
        }
        public void AddTab(TabView tab)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Tabs.Add(tab);
                context.SaveChanges();
            }
        }
    }
}
