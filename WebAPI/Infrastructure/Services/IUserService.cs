using Frontend.Models;
using WebAPI.Infrastructure.Specification;
using WebAPI.Models;

namespace WebAPI.Infrastructure.Services
{
    public interface IUserService
    {
        Task AddNewUser(RegisterModel registerModel);

        Task<User?> GetUserByUsername(string username);

        Task<ICollection<User>> GetAllUsers(UserSpecification spec);
    }
}
