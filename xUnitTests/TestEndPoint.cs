using Moq;
using WebAPI.Controllers;
using WebAPI.Infrastructure.Services;
using WebAPI.Infrastructure.Specification;
using WebAPI.Infrastructure.Specification.Params;
using WebAPI.Models;

namespace xUnitTests
{
    public class TestEndPoint
    {   
        [Fact]
        public void ShouldGetAllUsers()
        {
            // Setup user service
            var uParams = new UserParams();
            var specification = new UserSpecification(uParams);
            var user = new User
            {
                Id = 0,
                FirstName = "Admin",
                LastName = "Admin",
                Username = "Admin1",
                Email = "admin@mail.com",
                DateRegistered = DateTime.Now
            };

            var userService = new Mock<IUserService>();
            userService.Setup(x => x.GetAllUsers(specification).Result)
                .Returns(new List<User> { user });
            
            var getAllUsers = userService.Object.GetAllUsers(specification).Result;

            Assert.True(getAllUsers.Count == 1);
        }
    }
}