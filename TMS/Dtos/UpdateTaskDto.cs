namespace TMS.Dtos
{
	public class UpdateTaskDto
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public DateTime DueDate { get; set; }
        public int TasksListId { get; set; }
        public int UserId { get; set; }
    }
}

