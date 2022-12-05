using SocialNetwork.Classes;
using SocialNetwork.Classes.Models;
using SocialNetwork.Classes.User;
using WebAPI.Entities;

namespace WebAPI.Infrastructure.Services
{
    public interface IFollowService
    {
        Task<StatusCodeHandler<Follow>> AddNewFollow(FollowModel followModel);

        Task<StatusCodeHandler> RemoveFollowing(int userId, string username);

        Task<ICollection<Follow>> GetAllFollowings();

        Task<int> GetUserFollowersCount(string username);
    }
}
