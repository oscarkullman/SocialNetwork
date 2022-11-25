using Frontend.Models;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Classes;

namespace WebAPI.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly IUserService _userService;

        public AccountService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signinManager,
            IUserService userService)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _userService = userService;
        }

        public async Task<StatusCodeHandler> RegisterNewUser(RegisterModel registerModel)
        {
            var user = new IdentityUser { UserName = registerModel.Username, Email = registerModel.Email };

            // Kolla om användare redan finns
            if (await _userService.GetUserByUsername(user.UserName) != null)
            {
                return new StatusCodeHandler
                {
                    Code = 500,
                    Errors = new List<string>
                    {
                        $"A user with the username {registerModel.Username} already exists in the database."
                    }
                };
            }

            var newUser = await _userManager.CreateAsync(user, registerModel.Password);

            if (newUser.Succeeded)
            {
                await _userService.AddNewUser(registerModel);
                await _signinManager.SignInAsync(user, isPersistent: false);
                return new StatusCodeHandler(200, $"Successfully registered new user with username {user.UserName}");
            }

            return new StatusCodeHandler
            {
                Code = 500,
                Errors = new List<string>
                {
                    "An error occured while trying to register the new user."
                }
            };
        }
    }
}
