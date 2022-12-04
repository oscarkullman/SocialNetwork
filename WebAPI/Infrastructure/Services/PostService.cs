using Frontend.Models;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Post;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Specification;
using WebAPI.Infrastructure.Specification.Params;
using WebAPI.Models;

namespace WebAPI.Infrastructure.Services
{
    public class PostService  : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserService _userService;

        public PostService(
            IPostRepository postRepository,
            IUserService userService)
        {
            _postRepository = postRepository;
            _userService = userService;
        }
        
        public async Task<StatusCodeHandler<Post>> CreateNewPost(PostModel postModel)
        {
            var user = await _userService.GetUserByUsername(postModel.Username);
            
            var post = new Post
            {
                PostId = Guid.NewGuid(),
                WallOwner = postModel.WallOwner,
                Username = postModel.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Content = postModel.Content,
                DateCreated = DateTime.Now
            };

            var publishedPost = await _postRepository.CreateNewPost(post);
            return new StatusCodeHandler<Post>(200, $"Successfully published new post", publishedPost);
        }

        public async Task<ICollection<Post>> GetPostsByUsername(PostSpecification spec)
        {
            return await _postRepository.QueryWithSpec(spec);
        }

        public async Task<ICollection<Post>> GetPostsByWallOwner(string username)
        {
            var posts = await _postRepository.Query(x => x.WallOwner == username);

            posts = posts.AsQueryable()
                .OrderByDescending(x => x.DateCreated)
                .ToList();

            return posts;
        }

        public async Task<ICollection<Post>> GetPostsByUserAndFollowings(string username)
        {
            var user = await _userService.GetUserByUsername(username);

            var posts = await _postRepository
                .Query(x => x.WallOwner == username || 
                user.Follows.Select(p => p.Username).Contains(x.WallOwner));

            posts = posts.AsQueryable()
                .OrderByDescending(x => x.DateCreated)
                .ToList();

            return posts;
        }
    }
}
