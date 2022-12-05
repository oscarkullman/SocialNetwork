using SocialNetwork.Classes;
using SocialNetwork.Classes.Models;
using SocialNetwork.Classes.User;
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
        
        public async Task<StatusCodeHandler> AddNewFollow(FollowModel followModel)
        {
            var user = await _userService.GetUserByUsername(followModel.UserFollowing);
            
            if (user != null)
            {
                var follow = new Follow
                {
                    UserId = user.Id,
                    Username = followModel.UserToFollow
                };

                var result = await _followRepository.AddNewFollowing(follow);

                return result;
            }

            return new StatusCodeHandler(400, $"Something went wrong when trying to follow {followModel.UserToFollow}");
        }

        public async Task<StatusCodeHandler> RemoveFollowing(int userId, string username)
        {
            var follow = await _followRepository.QueryFirst(x => x.UserId == userId && x.Username == username);

            if (follow == null) return new StatusCodeHandler(400, "Something went wrong when trying to unfollow user.");

            var result = await _followRepository.RemoveFollowing(follow);

            return result;
        }

        public async Task<ICollection<Follow>> GetAllFollowings()
        {
            return await _followRepository.Query();
        }

        public async Task<int> GetUserFollowersCount(string username)
        {
            var followers = await _followRepository.Query(x => x.Username == username);

            return followers.Count;
        }
    }
}
