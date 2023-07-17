namespace TMS.Dtos
{
	public class CreatedTaskListDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> members { get; set; }
        public List<Task> Tasks { get; set; }
    }
}

