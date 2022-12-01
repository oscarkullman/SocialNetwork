using Frontend.Models;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Post;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Specification;
using WebAPI.Models;

namespace WebAPI.Infrastructure.Services
{
    public class PostService  : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        public async Task<StatusCodeHandler> CreateNewPost(PostModel postModel)
        {
            await _postRepository.CreateNewPost(postModel);
            return new StatusCodeHandler(200, $"Successfully posted");
        }

        public async Task<ICollection<Post?>> GetPostsByUsername(PostSpecification spec)
        {
            return await _postRepository.QueryWithSpec(spec);
        }
    }
}
