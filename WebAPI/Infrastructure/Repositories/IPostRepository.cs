using WebAPI.Entities;
using WebAPI.Repositories;
using SocialNetwork.Classes.Post;

namespace WebAPI.Infrastructure.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task CreateNewPost(PostModel postModel);
    }
}
