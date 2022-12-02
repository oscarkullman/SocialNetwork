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

        public PostRepository(
            DataContext context, 
            IUnitOfWork unitOfWork) 
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Post> CreateNewPost(Post post)
        {
            await _context.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();

            return post;
        }
    }
}
