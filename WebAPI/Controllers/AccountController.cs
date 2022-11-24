﻿using Frontend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes.Account;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/account/")]
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

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody]LoginModel loginModel)
        {
            // Logik för inloggning
            return Ok();
        }
        
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody]RegisterModel registerModel)
        {
            var user = new IdentityUser { UserName = registerModel.Username, Email = registerModel.Email };

            // Kolla om användare redan finns
            if (await _userService.GetUserByUsername(user.UserName) != null)
            {
                return BadRequest($"A user with the username {user.UserName} already exists in the database.");
            }

            var newUser = await _userManager.CreateAsync(user, registerModel.Password);

            if (newUser.Succeeded)
            {
                await _userService.AddNewUser(registerModel);
                await _siginManager.SignInAsync(user, isPersistent: false);
                return Ok($"Successfully registered new user with username {user.UserName}");
            }

            var allErrors = newUser.Errors.ToList()
                .Select(x => x.Description)
                .Aggregate((errors, error) => 
                    $"{(string.IsNullOrEmpty(errors) ? "" : $"{errors} ")}[{errors.Split("[").Length}]\"{error}\"");

            return BadRequest($"Error registering new user with username {user.UserName}. The request returned with the following errors: {allErrors}");
        }
    }
}
