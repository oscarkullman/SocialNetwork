using SocialNetwork.Classes;
using SocialNetwork.Classes.Post;
using WebAPI.Entities;
using WebAPI.Infrastructure.Specification;

namespace WebAPI.Infrastructure.Services
{
    public interface IPostService
    {
        Task<StatusCodeHandler<Post>> CreateNewPost(PostModel postModel);

        Task<ICollection<Post>> GetPostsByUsername(PostSpecification spec);

        Task<ICollection<Post>> GetPostsByWallOwner(string username);

        Task<ICollection<Post>> GetPostsByUserAndFollowings(string username);
    }
}
