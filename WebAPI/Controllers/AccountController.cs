using Frontend.Models;
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
        private readonly IAccountService _accountService;

        public AccountController(
            IAccountService accountService)
        {
            _accountService = accountService;
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
            var result = await _accountService.RegisterNewUser(registerModel);

            if (result.IsSuccessful)
            {
                return Ok(result.Message);
            }

            // Om registreringen nmisslyckadess, returnera en sträng med alla felmeddelanden
            var allErrors = "The request returned with the following errors:";

            if (result.Errors != null)
            {
                foreach (var error in result.Errors.Select((x, index) => new { Index = index, Message = x }))
                {
                    allErrors = $"{allErrors} [{error.Index + 1}] \"{error.Message}\"";
                }
            }

            return BadRequest(allErrors);
        }
    }
}
