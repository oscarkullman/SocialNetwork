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

        public async Task<StatusCodeHandler> AddNewFollowing(Follow follow)
        {
            await _context.AddAsync(follow);
            await _unitOfWork.SaveChangesAsync();
            
            return new StatusCodeHandler(200, "Added following to database successfully.");
        }
    }
}
