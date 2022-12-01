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
    public class AccountController : ControllerBase
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

            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPost("FollowUser")]
        public async Task<ActionResult<StatusCodeHandler>> Follow([FromBody]FollowModel followModel)
        {
            var result = await _accountService.Follow(followModel);
        }
    }
}
