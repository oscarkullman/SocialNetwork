using SocialNetwork.Classes;
using SocialNetwork.Classes.Models;
using WebAPI.Entities;

namespace WebAPI.Infrastructure.Services
{
    public interface IFollowService
    {
        Task<StatusCodeHandler> AddNewFollow(FollowModel followModel);

        Task<ICollection<Follow>> GetAllFollowings();

        Task<int> GetUserFollowersCount(string username);
    }
}
