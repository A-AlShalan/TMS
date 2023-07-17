using Microsoft.EntityFrameworkCore;
using TMS.Dtos;
using TMS.Repositories;

namespace TMS.Helpers
{
	public class TeamHelper: ITeamRepository
    {
        private readonly AppDBContext _appDbContext;

        public TeamHelper(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Team>> GetTeams()
        {
            return await _appDbContext.Teams.ToListAsync();
        }

        public async Task<Team> CreateTeam(TeamDto teamInput)
        {
            Team team = new Team()
            {
                Name = teamInput.Name
            };
            var result = _appDbContext.Teams.Add(team);
            _appDbContext.SaveChanges();
            return result.Entity;
        }
    }
}

