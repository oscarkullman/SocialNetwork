using SocialNetwork.Classes;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;

namespace WebAPI.Infrastructure.Services
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;
        private readonly IUserService _userService;
        
        public FollowService(
            IFollowRepository followRepository,
            IUserService userService)
        {
            _followRepository = followRepository;
            _userService = userService;
        }
        
        public async Task<StatusCodeHandler> AddNewFollow(string userFollowing, string userToFollow)
        {
            var user = await _userService.GetUserByUsername(userFollowing);
            
            var follow = new Follow
            {
                UserId = user.Id,
                Username = userToFollow
            };

            var result = await _followRepository.AddNewFollowing(follow);

            return result;
        }

        public async Task<ICollection<Follow>> GetAllFollowings()
        {
            return await _followRepository.Query();
        }
    }
}
