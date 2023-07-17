using TMS.Dtos;
using TMS.Repositories;

namespace TMS.Helpers
{
	public class UserHelper: IUserRepository
    {
        private AppDBContext _appDbContext;

        public UserHelper(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return _appDbContext.Users.ToList();
        }

        public async Task<User> createUser(UserDto input)
        {
            User user = new User()
            {
                Name = input.Name,
                TeamId = input.TeamId
            };
            var result = _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return result.Entity;
        }
    }
}

