using Moq;
using WebAPI.Entities;
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
                    Id = 1,
                    FirstName = "Max",
                    LastName = "Almroth",
                    Username = "Masken1",
                    Email = "max@mail.com",
                    Follows = new List<Follow>(),
                    DateRegistered = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    FirstName = "Roman",
                    LastName = "Parker",
                    Username = "RomPa23",
                    Email = "roman@mail.com",
                    Follows = new List<Follow>(),
                    DateRegistered = DateTime.Now.AddDays(1)
                },
                new User
                {
                    Id = 3,
                    FirstName = "Oscar",
                    LastName = "Kullman",
                    Username = "Kullen12",
                    Email = "oscar@mail.com",
                    Follows = new List<Follow>(),
                    DateRegistered = DateTime.Now.AddDays(2)
                }
            };
        }

        [Fact]
        public void ShouldGetAllUsers()
        {
            // Setup
            var uParams = new UserParams();
            var specification = new UserSpecification(uParams);

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.QueryWithSpec(It.IsAny<UserSpecification>()).Result)
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
            // Setup
            var spec = new UserSpecification(x => x.Username == username);

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.QueryFirstWithSpec(It.IsAny<UserSpecification>()).Result)
                .Returns(_users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower()));

            // Act
            var userService = new UserService(userRepository.Object);

            var getUserByUsername = userService.GetUserByUsername(username).Result;

            // Assert
            Assert.True(getUserByUsername.Username == username);
        }
    }
}
