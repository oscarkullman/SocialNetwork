using Frontend.Models;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Account;

namespace WebAPI.Infrastructure.Services
{
    public interface IAccountService
    {
        Task<StatusCodeHandler> Register(RegisterModel registerModel);

        Task<StatusCodeHandler> LogIn(LogInModel logInModel);

        Task<StatusCodeHandler> Follow(FollowModel followModel);
    }
}
