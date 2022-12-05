using SocialNetwork.Classes;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Repositories
{
    public class FollowRepository : Repository<Follow>, IFollowRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public FollowRepository(
            DataContext context,
            IUnitOfWork unitOfWork) 
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StatusCodeHandler<Follow>> AddNewFollowing(Follow follow)
        {
            await _context.AddAsync(follow);
            await _unitOfWork.SaveChangesAsync();
            
            return new StatusCodeHandler<Follow>(200, $"Successfully started following {follow.Username}.", follow);
        }

        public async Task<StatusCodeHandler> RemoveFollowing(Follow follow)
        {
            _context.Remove(follow);
            await _unitOfWork.SaveChangesAsync();

            return new StatusCodeHandler(200, $"Stopped following {follow.Username} successfully.");
        }
    }
}
