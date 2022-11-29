using SocialNetwork.Classes.Frontend;

namespace xUnitTests.Frontend
{
    public class SignInValidatorTests
    {
        [Fact]
        public void ShouldBeAbleToLogInUsingValidUsername()
        {
            var result = SignInValidator.CheckUsername("Username");

            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("U")]
        [InlineData("Us")]
        [InlineData("Use")]
        [InlineData("User")]
        public void ShouldNotBeAbleToLogInUsingInvalidUsername(string username)
        {
            var result = SignInValidator.CheckUsername(username);

            Assert.False(result);
        }

        [Fact]
        public void ShouldBeAbleToLogInUsingValidPassword()
        {
            var result = SignInValidator.CheckPassword("Password123");

            Assert.True(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("P")]
        [InlineData("Pa")]
        [InlineData("Pas")]
        [InlineData("Pass")]
        [InlineData("Passw")]
        public void ShouldNotBeAbleToLogInUsingInvalidPassword(string password)
        {
            var result = SignInValidator.CheckPassword(password);

            Assert.False(result);
        }
    }
}
