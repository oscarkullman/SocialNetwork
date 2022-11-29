using WebAPI.Entities;

namespace WebAPI.Infrastructure.Services
{
    public class PostService : IPostService
    {
        public PostService()
        {

        }
        
        public async Task<List<Post>> CreateNewPost(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Post>> GetPostsByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
