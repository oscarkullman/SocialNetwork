using Frontend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes.Account;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/accounts/")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _siginManager;
        private readonly IUserService _userService;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> siginManager,
            IUserService userService)
        {
            _userManager = userManager;
            _siginManager = siginManager;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task Login([FromBody]LoginModel loginModel)
        {
            // Logik för inloggning
        }
        
        [HttpPost("register")]
        public async Task Register([FromBody]RegisterModel registerModel)
        {
            var user = new IdentityUser { UserName = registerModel.Username, Email = registerModel.Email };

            // Kolla om användare redan finns
            if (await _userService.GetUser(user.UserName) != null)
            {
                // Do something
                return;
            }

            var newUser = await _userManager.CreateAsync(user, registerModel.Password);

            if (newUser.Succeeded)
            {
                await _userService.AddNewUser(registerModel);
                await _siginManager.SignInAsync(user, isPersistent: false);
            }
        }
    }
}
