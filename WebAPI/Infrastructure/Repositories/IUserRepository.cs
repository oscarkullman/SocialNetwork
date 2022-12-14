using Frontend.Models;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddNewUser(RegisterModel registerModel);
    }
}
