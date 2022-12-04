using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Models;
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

        [HttpPost("AddNewFollow")]
        public async Task<ActionResult<StatusCodeHandler>> AddNewFollow([FromBody]FollowModel followModel)
        {
            var result = await _followService.AddNewFollow(followModel);

            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

        [HttpGet("GetAllFollowings")]
        public async Task<ActionResult> GetAllFollowings()
        {
            var followings = await _followService.GetAllFollowings();
            
            return Ok(followings);
        }

        [HttpGet("GetUserFollowersCount/{username}")]
        public async Task<ActionResult<int>> GetUserFollowersCount(string username)
        {
            var followers = await _followService.GetUserFollowersCount(username);

            return Ok(followers);
        }
    }
}
