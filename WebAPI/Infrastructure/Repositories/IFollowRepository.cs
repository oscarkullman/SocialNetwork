using SocialNetwork.Classes;
using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Repositories
{
    public interface IFollowRepository : IRepository<Follow>
    {
        Task<StatusCodeHandler<Follow>> AddNewFollowing(Follow follow);

        Task<StatusCodeHandler> RemoveFollowing(Follow follow);
    }
}
