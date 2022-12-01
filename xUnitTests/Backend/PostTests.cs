using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Services;
using WebAPI.Infrastructure.Specification;
using WebAPI.Infrastructure.Specification.Params;

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

                    Username = "Rompa23",
                    FirstName = "Roman",

                    LastName = "Parker",

                    Content = "My first post, the wheater is very nice today! Have a good day my followers!",

                    DateCreated = DateTime.Now,
                },
                new Post
                {
                    PostId = Guid.NewGuid(),

                    Username = "Masken1",
                    FirstName = "Max",

                    LastName = "Almroth",

                    Content = "My first post, the wheater is very nice today! Have a good day my followers!",

                    DateCreated = DateTime.Now,
                },
                new Post
                {
                    PostId = Guid.NewGuid(),

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
            //Setup PostRepository mockup
            var postParams = new PostParams();
            var postSpecification = new PostSpecification(postParams);

            var postRepository = new Mock<IPostRepository>();
            postRepository.Setup(x => x.QueryWithSpec(postSpecification).Result)
                .Returns(_posts.FindAll(x => x.Username.ToLower() == usernamne.ToLower()));

            //Act
            var postService = new PostService(postRepository.Object);

            var getAllPosts = postService.GetPostsByUsername(postSpecification).Result;

            //Assert 
            Assert.True(getAllPosts.Count == 1 && getAllPosts.ToList()[0].Username == usernamne);
        }
    }
}
