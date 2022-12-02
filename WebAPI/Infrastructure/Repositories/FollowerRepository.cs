using Microsoft.EntityFrameworkCore;
using SocialNetwork.Classes.Account;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Infrastructure.Services;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Repositories
{
    public class FollowerRepository : Repository<Follower>, IFollowerRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public FollowerRepository(DataContext context, IUnitOfWork unitOfWork, IUserService userService) : base(context)
        {
            _unitOfWork = unitOfWork;   
            _userService = userService; 
        }
        public async Task FollowUser(FollowModel followModel)
        {
            var userToFollow = await _userService.GetUserByUsername(followModel.userNameToFollow);

            var currentUser = await _userService.GetUserByUsername(followModel.currentUser);

            var follow = new Follower
            {
                FollowerId = currentUser.Id,
                User = userToFollow
            };
            _context.Add(follow);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
