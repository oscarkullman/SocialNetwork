using Frontend.Models;
using SocialNetwork.Classes.Account;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Specification;
using WebAPI.Models;

namespace WebAPI.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddNewUser(RegisterModel registerModel)
        {
            await _userRepository.AddNewUser(registerModel);
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _userRepository.QueryFirst(x => x.Username.ToLower() == username.ToLower());
        }

        public async Task<ICollection<User>> GetAllUsers(UserSpecification spec)
        {
            return await _userRepository.QueryWithSpec(spec);
        }

        
    }
}
