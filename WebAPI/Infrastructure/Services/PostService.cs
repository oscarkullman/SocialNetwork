using SocialNetwork.Classes;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;

namespace WebAPI.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<StatusCodeHandler> CreateNewPost(Post post)
        {
            return new StatusCodeHandler(); ;
        }

        public async Task<ICollection<Post>> GetPostsByUsername(string username)
        {
            return new List<Post>();
        }
    }
}
