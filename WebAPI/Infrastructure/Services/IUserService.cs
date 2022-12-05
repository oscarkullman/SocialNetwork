using Frontend.Models;
using WebAPI.Infrastructure.Specification;
using WebAPI.Models;

namespace WebAPI.Infrastructure.Services
{
    public interface IUserService
    {
        Task AddNewUser(RegisterModel registerModel);

        Task<ICollection<User>> GetAllUsers(UserSpecification spec);

        Task<User?> GetUserByUsername(string username);

        Task<int> GetUserIdByUsername(string username);
    }
}
