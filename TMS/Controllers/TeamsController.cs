using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Dtos;
using TMS.Helpers;
using TMS.Repositories;

namespace TMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController: ControllerBase
	{

        private readonly ITeamRepository _teamHelper;

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamHelper = teamRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Team>> GetTeams()
        {
            return await _teamHelper.GetTeams();
         
        }

        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam(TeamDto input)
        {
            return await _teamHelper.CreateTeam(input);
        }
    }
}

