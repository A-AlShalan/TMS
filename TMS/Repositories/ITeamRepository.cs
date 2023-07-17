using Microsoft.AspNetCore.Mvc;
using TMS.Dtos;

namespace TMS.Repositories
{
	public interface ITeamRepository
	{
		Task<IEnumerable<Team>> GetTeams();
        Task<Team> CreateTeam(TeamDto teamInput);
    }
}

