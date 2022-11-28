using Frontend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Account;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/account/")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(
            IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<StatusCodeHandler>> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _accountService.Register(registerModel);

            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<StatusCodeHandler>> Login([FromBody]LogInModel loginModel)
        {
            var result = await _accountService.LogIn(loginModel);

            if (!result.IsSuccessful) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("LogOut")]
        public async Task<ActionResult<StatusCodeHandler>> LogOut()
        {
            var name = User.Identity?.Name;

            if (name == null)
                return BadRequest(new StatusCodeHandler(400, "User already signed out."));

            var result = await _accountService.LogOut(name);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("CheckAuthorization")]
        public async Task<ActionResult<StatusCodeHandler>> CheckAuthorization()
        {
            return Ok(new StatusCodeHandler(200, "You are authorized."));            
        }
    }
}
