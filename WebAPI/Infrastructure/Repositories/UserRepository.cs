using Frontend.Models;
using SocialNetwork.Classes.Account;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Infrastructure.Services;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserRepository(DataContext context, IUnitOfWork unitOfWork, IUserService userService) : base(context)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task AddNewUser(RegisterModel registerModel)
        {
            var user = new User
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Username = registerModel.Username,
                Email = registerModel.Email,
                DateRegistered = DateTime.Now
            };

            _context.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
        
        public async Task FollowUser(FollowModel followModel)
        {
            var userToFollow = await _userService.GetUserByUsername(followModel.userNameToFollow);

            var follow = new Follower
            {
                FollowerId = Guid.NewGuid(),
                Username = followModel.userNameToFollow
            };
            _context.Add(follow);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
