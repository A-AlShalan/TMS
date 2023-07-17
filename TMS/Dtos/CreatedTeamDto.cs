namespace TMS.Dtos
{
	public class CreatedTeamDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> users { get; set; }
    }
}

