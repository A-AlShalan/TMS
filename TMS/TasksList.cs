using System.ComponentModel.DataAnnotations;

namespace TMS
{
	public class TasksList
	{
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
    }
}

