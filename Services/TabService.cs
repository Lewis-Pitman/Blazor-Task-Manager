using BlazorTaskManager.Models;

namespace BlazorTaskManager.Services
{
    public class TabService
    {
        public List<(Guid, string)> GetAllTabs()
        {
            // Returns all tabs with their Id and Label
            return null;
        }

        public TabView GetTab(Guid tabId)
        {
            // Returns a TabView with the given Id
            return null;
        }
    }
}
