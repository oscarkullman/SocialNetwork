using SocialNetwork.Classes;
using WebAPI.Entities;

namespace WebAPI.Infrastructure.Services
{
    public interface IPostService
    {
        Task<StatusCodeHandler> CreateNewPost(Post post);

        Task<ICollection<Post>> GetPostsByUsername(string username);
    }
}
