using System.ComponentModel.DataAnnotations;

namespace TMS
{
	public class Team
	{
        [Required, Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<User> users { get; set; }
    }
}

