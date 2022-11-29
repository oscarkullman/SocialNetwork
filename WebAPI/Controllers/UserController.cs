using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrastructure.Services;
using WebAPI.Infrastructure.Specification;
using WebAPI.Infrastructure.Specification.Params;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<ICollection<User>>> GetAllUsers([FromQuery]UserParams userParams)
        {
            var spec = new UserSpecification(userParams);

            var users = await _userService.GetAllUsers(spec);

            if (users.Count > 0)
            {
                return Ok(users);
            }

            return NotFound();
        }

        [HttpGet("GetUserByUsername/{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);

            return Ok(user);
        }
    }
}
