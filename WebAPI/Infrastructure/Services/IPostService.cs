using SocialNetwork.Classes;
using SocialNetwork.Classes.Post;
using WebAPI.Entities;
using WebAPI.Infrastructure.Specification;

namespace WebAPI.Infrastructure.Services
{
    public interface IPostService
    {
        Task<StatusCodeHandler> CreateNewPost(PostModel postModel);

        Task<ICollection<Post>> GetPostsByUsername(PostSpecification spec);
    }
}
