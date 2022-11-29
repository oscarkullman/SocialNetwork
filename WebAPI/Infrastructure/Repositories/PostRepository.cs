using Frontend.Models;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Classes.Post;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {

        private readonly IUnitOfWork _unitOfWork;

        public PostRepository(DataContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateNewPost(PostModel postModel)
        {
            var post = new Post
            {
                FirstName = postModel.FirstName,
                LastName = postModel.LastName,
                Username = postModel.Username,
                PostId = Guid.NewGuid(),
                DateCreated = DateTime.Now
            };

            _context.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
