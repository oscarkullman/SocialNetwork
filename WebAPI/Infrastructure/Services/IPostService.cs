using WebAPI.Entities;

namespace WebAPI.Infrastructure.Services
{
    public interface IPostService
    {
        Task<List<Post>> CreateNewPost(Post post);

        Task<ICollection<Post>> GetPostsByUsername(string username);
    }
}
