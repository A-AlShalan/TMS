using System.ComponentModel.DataAnnotations;
namespace TMS
{
	public class Tasks
	{
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string ? Description { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public TaskStatus TaskStatus { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int TasksListId { get; set; }
        public int ? UserId { get; set; }
    }
}

