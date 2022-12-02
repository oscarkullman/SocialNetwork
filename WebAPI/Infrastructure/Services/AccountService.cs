using Frontend.Models;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Account;
using Microsoft.AspNetCore.Http;
using WebAPI.Infrastructure.Repositories;

namespace WebAPI.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly IUserService _userService;
        private readonly IFollowerRepository _followerRepository;

        public AccountService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signinManager,
            IUserService userService,
            IFollowerRepository followerRepository
            )
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _userService = userService;
            _followerRepository = followerRepository;   
        }
        
        public async Task<StatusCodeHandler> Register(RegisterModel registerModel)
        {
            var user = new IdentityUser { UserName = registerModel.Username, Email = registerModel.Email };

            // Kolla om användare redan finns
            if (await _userService.GetUserByUsername(user.UserName) != null)
            {
                return new StatusCodeHandler
                {
                    Code = 409,
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

                // Log in user
                var loginModel = new LogInModel
                {
                    Username = registerModel.Username,
                    Password = registerModel.Password
                };
                var loginResult = await LogIn(loginModel);
                
                if (!loginResult.IsSuccessful)
                {
                    return new StatusCodeHandler(400, $"Registration was successful, but an error occured during login.");
                }

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

        public async Task<StatusCodeHandler> LogIn(LogInModel logInModel)
        {
            var user = await _userManager.FindByNameAsync(logInModel.Username);

            if (user != null)
            {   
                var checkPassword = await _userManager.CheckPasswordAsync(user, logInModel.Password);

                if (checkPassword)
                {
                    return new StatusCodeHandler(200, $"Successfully signed in as {logInModel.Username}");
                }
            }

            return new StatusCodeHandler(401, "Login attempt failed.");
        }
        public async Task<StatusCodeHandler> FollowUser(FollowModel followModel)
        {
            await _followerRepository.FollowUser(followModel);
            return new StatusCodeHandler(200);
        }

     
    }
}
