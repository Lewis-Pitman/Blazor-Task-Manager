namespace BlazorTaskManager.Models
{
    public class TabView
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public List<TaskItem> TaskList { get; set; }
        public bool ShowCloseIcon { get; set; } = true;
    }
}
