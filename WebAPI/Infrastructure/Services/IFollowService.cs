using SocialNetwork.Classes;
using WebAPI.Entities;

namespace WebAPI.Infrastructure.Services
{
    public interface IFollowService
    {
        Task<StatusCodeHandler> AddNewFollow(string userFollowing, string userToFollow);

        Task<ICollection<Follow>> GetAllFollowings();
    }
}
