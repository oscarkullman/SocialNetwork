using SocialNetwork.Classes.Frontend;

namespace xUnitTests.Frontend
{
    public class PasswordValidatorTests
    {
        [Fact]
        public void ShouldBeAbleToUseValidPassword()
        {
            var result = PasswordValidator.Validate("Password123");

            Assert.True(result.Success);
        }

        [Theory]
        [InlineData("password123")]
        [InlineData("Password")]
        [InlineData("Passw")]
        public void ShouldNotBeAbleToUseInvalidPassword(string password)
        {
            var result = PasswordValidator.Validate(password);

            Assert.False(result.Success);
        }

        [Fact]
        public void ShouldBeAbleToUsePasswordWithSixCharacters()
        {
            var result = PasswordValidator.CheckLength("Length");

            Assert.True(result);
        }

        [Fact]
        public void ShouldNotBeAbleToUsePasswordWithLessThanSixCharacters()
        {
            var result = PasswordValidator.CheckLength("Short");

            Assert.False(result);
        }

        [Fact]
        public void ShouldBeAbleToUsePasswordWithUpperCase()
        {
            var result = PasswordValidator.CheckForUpperCase("Password");

            Assert.True(result);
        }

        [Fact]
        public void ShouldNotBeAbleToUsePasswordWithoutUpperCase()
        {
            var result = PasswordValidator.CheckForUpperCase("password");

            Assert.False(result);
        }

        [Fact]
        public void ShouldBeAbleToUsePasswordWithNumeric()
        {
            var result = PasswordValidator.CheckForNumeric("Password1");

            Assert.True(result);
        }

        [Fact]
        public void ShouldNotBeAbleToUsePasswordWithoutNumeric()
        {
            var result = PasswordValidator.CheckForNumeric("Password");

            Assert.False(result);
        }
    }
}
