using SocialNetwork.Classes;
using SocialNetwork.Classes.Models;
using SocialNetwork.Classes.User;
using WebAPI.Entities;

namespace WebAPI.Infrastructure.Services
{
    public interface IFollowService
    {
        Task<StatusCodeHandler> AddNewFollow(FollowModel followModel);

        Task<StatusCodeHandler> RemoveFollow(FollowDto followDto);

        Task<ICollection<Follow>> GetAllFollowings();

        Task<int> GetUserFollowersCount(string username);
    }
}
