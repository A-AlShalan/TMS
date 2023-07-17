using System.ComponentModel.DataAnnotations;

namespace TMS
{
	public class Loggings
	{
        public int Id { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
    }
}

