using Frontend.Models;
using SocialNetwork.Classes;

namespace WebAPI.Infrastructure.Services
{
    public interface IAccountService
    {
        Task<StatusCodeHandler> RegisterNewUser(RegisterModel registerModel);
    }
}
