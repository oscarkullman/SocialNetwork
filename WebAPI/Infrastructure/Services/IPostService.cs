using SocialNetwork.Classes;
using SocialNetwork.Classes.Post;
using WebAPI.Entities;

namespace WebAPI.Infrastructure.Services
{
    public interface IPostService
    {
        Task<StatusCodeHandler> CreateNewPost(PostModel postModel);

        Task<Post> GetPostsByUsername(string username);
    }
}
