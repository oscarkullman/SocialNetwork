using Frontend.Models;
using WebAPI.Models;

namespace WebAPI.Infrastructure.Services
{
    public interface IUserService
    {
        Task AddNewUser(RegisterModel registerModel);

        Task<User?> GetUser(string username);
    }
}
