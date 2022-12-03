using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/follow/")]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;
        
        public FollowController(
            IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost("AddNewFollow/{userFollowing}/{userToFollow}")]
        public async Task<ActionResult<StatusCodeHandler>> AddNewFollow(string userFollowing, string userToFollow)
        {
            var result = await _followService.AddNewFollow(userFollowing, userToFollow);

            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }

        [HttpGet("GetAllFollowings")]
        public async Task<ActionResult> GetAllFollowings()
        {
            var followings = await _followService.GetAllFollowings();
            
            return Ok(followings);
        }
    }
}
