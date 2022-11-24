using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Test")]
        public async Task<string> TestEndpoint()
        {
            return "I work! Yay!";
        }
    }
}
