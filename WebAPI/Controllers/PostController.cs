using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Post;
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
        private readonly IMapper _mapper;
        
        public PostController(
            IPostService postService, 
            IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpPost("CreateNewPost")]
        public async Task<ActionResult<StatusCodeHandler<PostDto>>> CreateNewPost([FromBody]PostModel postModel)
        {
            var post = await _postService.CreateNewPost(postModel);
            var mappedPost = _mapper.Map<PostDto>(post.Content);

            return Ok(new StatusCodeHandler<PostDto>(200, "Post was created successfully.", mappedPost));
        }

        [HttpGet("GetPostsByUsername")]
        public async Task<ActionResult<ICollection<PostDto>>> GetPostsByUsername([FromQuery] PostParams postParams)
        {
            var postSpec = new PostSpecification(postParams);
            var posts = await _postService.GetPostsByUsername(postSpec);

            return Ok(_mapper.Map<List<PostDto>>(posts));
        }

        [HttpGet("GetPostsByWallOwner/{username}")]
        public async Task<ActionResult<ICollection<PostDto>>> GetPostsByWallOwner(string username)
        {
            var posts = await _postService.GetPostsByWallOwner(username);

            return Ok(_mapper.Map<List<PostDto>>(posts));
        }
    }
}
