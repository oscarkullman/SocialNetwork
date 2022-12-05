using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Models;
using SocialNetwork.Classes.User;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/follow/")]
    public class FollowController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFollowService _followService;
        
        public FollowController(
            IMapper mapper,
            IFollowService followService)
        {
            _mapper = mapper;
            _followService = followService;
        }

        [HttpPost("AddNewFollow")]
        public async Task<ActionResult<StatusCodeHandler<FollowDto>>> AddNewFollow([FromBody]FollowModel followModel)
        {
            var result = await _followService.AddNewFollow(followModel);

            if (result.IsSuccessful)
            {
                return Ok(_mapper.Map<StatusCodeHandler<FollowDto>>(result));
            }
            
            return BadRequest(_mapper.Map<StatusCodeHandler<FollowDto>>(result));
        }

        [HttpDelete("RemoveFollowing/{userId}/{username}")]
        public async Task<ActionResult<StatusCodeHandler>> RemoveFollowing(int userId, string username)
        {
            var result = await _followService.RemoveFollowing(userId, username);

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
