using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTaskManager.Models
{
    public class TaskItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TabId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? dueDate { get; set; }
    }
}
