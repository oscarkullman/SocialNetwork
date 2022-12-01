using Frontend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Classes.Post;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Infrastructure.Services;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;


        public PostRepository(DataContext context, IUnitOfWork unitOfWork, IUserService userService) : base(context)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task CreateNewPost(PostModel postModel)
        {
            var user = await _userService.GetUserByUsername(postModel.Username);

            var post = new Post
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Content = postModel.Content,
                Username = postModel.Username,
                PostId = Guid.NewGuid(),
                DateCreated = DateTime.Now
            };

            _context.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
