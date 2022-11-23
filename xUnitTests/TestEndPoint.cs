using WebAPI.Controllers;

namespace xUnitTests
{
    public class TestEndPoint
    {
        [Fact]
        public async void TestEndpoint()
        {
            //Arrange
            UsersController usersController = new UsersController();
            var expectedValue = "I work! Yay!";
            var testEndpointValue = await usersController.TestEndpoint();

            //Assert
            Assert.Equal(expectedValue, testEndpointValue);
        }
    }
}