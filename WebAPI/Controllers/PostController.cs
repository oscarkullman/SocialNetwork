using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Post;
using WebAPI.Entities;
using WebAPI.Infrastructure.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/post/")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        
        public PostController(
            IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("CreateNewPost")]
        public async Task<ActionResult<StatusCodeHandler>> CreateNewPost([FromBody]PostModel postModel)
        {
            _postService.CreateNewPost(postModel);
            return Ok(new StatusCodeHandler(200, "Post was created successfully."));
        }

        [HttpGet("GetPostsByUsername/{username}")]
        public async Task<ActionResult<ICollection<Post>>> GetPostsByUsername(string username)
        {
            var posts = await _postService.GetPostsByUsername(username);
            return Ok(posts);
        }
    }
}
