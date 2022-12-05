using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Services;

namespace xUnitTests.Backend
{
    public class FollowTests
    {
        private List<Follow> _follows;

        public FollowTests()
        {
            _follows = new List<Follow> 
            {
                new Follow
                {
                    UserId = 1,
                    Username = "Kullen22"
                },
                new Follow
                {
                    UserId= 2,
                    Username = "Mask2"
                },
                new Follow
                {
                    UserId = 3,
                    Username = "Romme1337"
                },
                new Follow
                {
                    UserId = 4,
                    Username = "Anonym"
                }

            }; 
            
        }
        [Fact]
        public void ShouldBeAbleToGetAllFollowings()
        {
            //Assert
            var followRepository = new Mock<IFollowRepository>();
            followRepository.Setup(x => x.Query().Result).Returns(_follows);

            var userService = new Mock<IUserService>();

            //Act
            var followService = new FollowService(followRepository.Object, userService.Object);
                

            var result = followService.GetAllFollowings().Result;

            Assert.True(result.Count == 4);
        }
        [Theory]
        [InlineData("Mask2")]
        [InlineData("Kullen22")]
        [InlineData("Romme1337")]
        [InlineData("Anonym")]
        public void ShouldGetUserFollowingsCount(string username)
        {
            //Setup
            var followRepository = new Mock<IFollowRepository>();
                followRepository.Setup(x => x.Query(It.IsAny<Expression<Func<Follow, bool>>>()).Result)
                .Returns(_follows.Where(x => x.Username.ToLower() == username.ToLower()).ToList());

            var userService = new Mock<IUserService>();

            //Act
            var followService = new FollowService(followRepository.Object, userService.Object);

            var userFollowingCount = (followService.GetUserFollowersCount(username).Result);

            //Assert
            Assert.Equal(1, userFollowingCount);
        }
    }
}
