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
        public async Task<ActionResult<StatusCodeHandler>> CreateNewPost([FromBody]PostModel postModel)
        {
            await _postService.CreateNewPost(postModel);
            return Ok(new StatusCodeHandler(200, "Post was created successfully."));
        }

        [HttpGet("GetPostsByUsername")]
        public async Task<ActionResult<ICollection<PostDto>>> GetPostsByUsername([FromQuery]PostParams postParams)
        {
            var postSpec = new PostSpecification(postParams);
            var posts = await _postService.GetPostsByUsername(postSpec);

            return Ok(_mapper.Map<List<PostDto>>(posts));
        }
    }
}
