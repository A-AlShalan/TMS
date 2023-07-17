using System.ComponentModel.DataAnnotations;

namespace TMS
{
	public class User
	{
        [Required, Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TeamId { get; set; }
        //public Team Team { get; set; }
        public ICollection<Tasks> tasks { get; set; }
    }
}

