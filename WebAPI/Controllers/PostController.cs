using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Post;
using WebAPI.Entities;
using WebAPI.Infrastructure.Services;
using WebAPI.Infrastructure.Specification;
using WebAPI.Infrastructure.Specification.Params;

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

        [HttpGet("GetPostsByUsername")]
        public async Task<ActionResult<ICollection<Post>>> GetPostsByUsername([FromQuery]PostParams postParams)
        {
            var postSpec = new PostSpecification(postParams);
            var posts = await _postService.GetPostsByUsername(postSpec);
            return Ok(posts);
        }
    }
}
