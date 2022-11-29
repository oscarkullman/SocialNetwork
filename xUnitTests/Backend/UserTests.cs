using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Repositories;
using WebAPI.Infrastructure.Services;
using WebAPI.Infrastructure.Specification;
using WebAPI.Infrastructure.Specification.Params;
using WebAPI.Models;

namespace xUnitTests.Backend
{
    public class UserTests
    {
        private List<User> _users; 
        
        public UserTests()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = 0,
                    FirstName = "Max",
                    LastName = "Almroth",
                    Username = "Masken1",
                    Email = "max@mail.com",
                    DateRegistered = DateTime.Now
                },
                new User
                {
                    Id = 1,
                    FirstName = "Roman",
                    LastName = "Parker",
                    Username = "RomPa23",
                    Email = "roman@mail.com",
                    DateRegistered = DateTime.Now.AddDays(1)
                },
                new User
                {
                    Id = 2,
                    FirstName = "Oscar",
                    LastName = "Kullman",
                    Username = "Kullen12",
                    Email = "oscar@mail.com",
                    DateRegistered = DateTime.Now.AddDays(2)
                }
            };
        }

        [Fact]
        public void ShouldGetAllUsers()
        {
            // Setup UserReporitory mockup
            var uParams = new UserParams();
            var specification = new UserSpecification(uParams);

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.QueryWithSpec(specification).Result)
                .Returns(_users);

            // Act
            var userService = new UserService(userRepository.Object);

            var getAllUsers = userService.GetAllUsers(specification).Result;

            // Assert
            Assert.True(getAllUsers.Count == 3);
        }

        [Theory]
        [InlineData("Masken1")]
        [InlineData("RomPa23")]
        [InlineData("Kullen12")]
        public void ShouldBeAbleToGetUserByUsername(string username)
        {
            // Setup UserReporitory mockup
            var uParams = new UserParams();
            var specification = new UserSpecification(uParams);

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.QueryFirst(x => x.Username.ToLower() == username.ToLower()).Result)
                .Returns(_users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower()));

            // Act
            var userService = new UserService(userRepository.Object);

            var getUserByUsername = userService.GetUserByUsername(username).Result;

            // Assert
            Assert.True(getUserByUsername?.Username == username);
        }
    }
}
