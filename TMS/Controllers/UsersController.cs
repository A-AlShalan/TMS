using Microsoft.AspNetCore.Mvc;
using TMS.Dtos;
using TMS.Repositories;

namespace TMS
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
	{
        private readonly IUserRepository _userHelper;

        public UsersController(IUserRepository userRepository)
        {
            _userHelper = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userHelper.GetUsers();
        }

        [HttpPost]
        public async Task<ActionResult<User>> createUser([FromBody] UserDto input)
        {
            return await _userHelper.createUser(input);
        }
    }
}

