using TMS.Dtos;

namespace TMS.Repositories
{
	public interface IUserRepository
	{
        Task<IEnumerable<User>> GetUsers();
        Task<User> createUser(UserDto user);
    }
}

