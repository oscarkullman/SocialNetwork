using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Infrastructure.Services;
using WebAPI.Infrastructure.Specification;
using WebAPI.Infrastructure.Specification.Params;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<ICollection<UserDto>>> GetAllUsers([FromQuery]UserParams userParams)
        {
            var spec = new UserSpecification(userParams);

            var users = await _userService.GetAllUsers(spec);

            return Ok(_mapper.Map<List<UserDto>>(users));
        }

        [HttpGet("GetUserByUsername/{username}")]
        public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);

            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}
