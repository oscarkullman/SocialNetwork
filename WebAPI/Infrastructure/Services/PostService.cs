using Frontend.Models;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;

namespace WebAPI.Infrastructure.Services
{
    public class PostService  //IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        //public async Task<List<Post>> CreateNewPost(Post post)
        //{
        //    await _postRepository.CreateNewPost(post);
        //}

        public async Task<ICollection<Post>> GetPostsByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
