using Moq;
using System.Linq.Expressions;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Services;
using WebAPI.Infrastructure.Specification;
using WebAPI.Infrastructure.Specification.Params;
using WebAPI.Models;

namespace xUnitTests.Backend
{
    public class PostTests
    {
        private List<Post> _posts;

        public PostTests()
        {
            _posts = new List<Post>{
                new Post
                {
                    PostId = Guid.NewGuid(),
                    WallOwner = "Masken1",
                    Username = "Rompa23",
                    FirstName = "Roman",
                    LastName = "Parker",
                    Content = "My first post, the wheater is very nice today! Have a good day my followers!",
                    DateCreated = DateTime.Now,
                },
                new Post
                {
                    PostId = Guid.NewGuid(),
                    WallOwner = "Masken1",
                    Username = "Masken1",
                    FirstName = "Max",
                    LastName = "Almroth",
                    Content = "My first post, the wheater is very nice today! Have a good day my followers!",
                    DateCreated = DateTime.Now,
                },
                new Post
                {
                    PostId = Guid.NewGuid(),
                    WallOwner = "Kullen12",
                    Username = "Kullen12",
                    FirstName = "Oscar",
                    LastName = "Kullman",
                    Content = "My first post, the wheater is very nice today! Have a good day my followers!",
                    DateCreated = DateTime.Now,
                },

            };
        }

        [Theory]
        [InlineData("Rompa23")]
        [InlineData("Masken1")]
        [InlineData("Kullen12")]
        public void ShouldGetPostsByUsername(string usernamne)
        {
            //Setup
            var postParams = new PostParams();
            var spec = new PostSpecification(postParams);

            var postRepository = new Mock<IPostRepository>();
            postRepository.Setup(x => x.QueryWithSpec(It.IsAny<PostSpecification>()).Result)
                .Returns(_posts.Where(x => x.Username.ToLower() == usernamne.ToLower()).ToList());

            var userService = new Mock<IUserService>();

            //Act
            var postService = new PostService(postRepository.Object, userService.Object);

            var getPostsByUsername = postService.GetPostsByUsername(spec).Result;

            //Assert 
            Assert.True(getPostsByUsername.All(x => x.Username == usernamne));
        }

        [Fact]
        public void ShouldGetPostsByWallOwner()
        {
            var postRepository = new Mock<IPostRepository>();
            postRepository.Setup(x => x.Query(It.IsAny<Expression<Func<Post, bool>>>()).Result)
                .Returns(_posts.Where(x => x.WallOwner == "Masken1").ToList());

            var userService = new Mock<IUserService>();

            //Act
            var postService = new PostService(postRepository.Object, userService.Object);

            var getPostsByWallOwner = postService.GetPostsByWallOwner("Masken1").Result;

            //Assert 
            Assert.True(getPostsByWallOwner.All(x => x.WallOwner == "Masken1"));
        }

        [Fact]
        public void ShouldGetPostsByUserAndFollowings()
        {
            // Setup
            var user = new User
            {
                Id = 1,
                FirstName = "Max",
                LastName = "Almroth",
                Username = "Masken1",
                Email = "max@mail.com",
                Follows = new List<Follow>
                {
                    new Follow { Id = 1, Username = "Kullen12" }
                },
                DateRegistered = DateTime.Now
            };

            var postRepository = new Mock<IPostRepository>();
            postRepository.Setup(x => x.Query(It.IsAny<Expression<Func<Post, bool>>>()).Result)
                .Returns(_posts.Where(x => x.WallOwner == user.Username || 
                        user.Follows.Select(p => p.Username).Contains(x.WallOwner)).ToList());

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.GetUserByUsername(It.IsAny<string>()).Result)
                .Returns(user);

            // Act
            var postService = new PostService(postRepository.Object, userService.Object);

            var getPostsByUserAndFollowings = postService.GetPostsByUserAndFollowings("Masken1").Result;

            // Assert
            Assert.True(getPostsByUserAndFollowings.All(x => x.WallOwner == user.Username || user.Follows.Select(p => p.Username).Contains(x.WallOwner)));
        }
    }
}
