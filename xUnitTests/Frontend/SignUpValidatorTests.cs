using Frontend.Models;
using SocialNetwork.Classes.Frontend;

namespace xUnitTests.Frontend
{
    public class SignUpValidatorTests
    {
        [Fact]
        public void ShouldBeAbleToRegisterUserWithValidForm()
        {
            var registerModel = new RegisterModel
            {
                FirstName = "First",
                LastName = "Last",
                Username = "Username",
                Email = "test@mail.com",
                Password = "Password123",
                RepeatPassword = "Password123"
            };

            var result = SignUpValidator.Validate(registerModel);

            Assert.True(result.Success);
        }

        [Fact]
        public void ShouldNotBeAbleToRegisterUserWithInvalidForm()
        {
            var registerModel = new RegisterModel
            {
                FirstName = "F",
                LastName = "L",
                Username = "User",
                Email = "t@m.c",
                Password = "password",
                RepeatPassword = "pass"
            };

            var result = SignUpValidator.Validate(registerModel);

            Assert.False(result.Success);
        }

        [Fact]
        public void ShouldBeAbleToRegisterValidFirstName()
        {
            var result = SignUpValidator.CheckFirstName("Test");

            Assert.True(result);
        }

        [Theory]
        [InlineData("T")]
        [InlineData("Test1")]
        [InlineData("Test_")]
        public void ShouldNotBeAbleToRegisterInvalidFirstName(string firstName)
        {
            var result = SignUpValidator.CheckFirstName(firstName);

            Assert.False(result);
        }

        [Fact]
        public void ShouldBeAbleToRegisterValidLastName()
        {
            var result = SignUpValidator.CheckFirstName("Test");

            Assert.True(result);
        }

        [Theory]
        [InlineData("T")]
        [InlineData("Test1")]
        [InlineData("Test_")]
        public void ShouldNotBeAbleToRegisterInvalidLastName(string lastName)
        {
            var result = SignUpValidator.CheckFirstName(lastName);

            Assert.False(result);
        }

        [Fact]
        public void ShouldBeAbleToRegisterValidUsername()
        {
            var result = SignUpValidator.CheckUsername("Test_123");

            Assert.True(result);
        }

        [Theory]
        [InlineData("Name")]
        [InlineData("Name?")]
        [InlineData("Name-Test")]
        public void ShouldNotBeAbleToRegisterInvalidUsername(string username)
        {
            var result = SignUpValidator.CheckUsername(username);

            Assert.False(result);
        }

        [Fact]
        public void ShouldBeAbleToRegisterValidEmail()
        {
            var result = SignUpValidator.CheckEmail("test@mail.com");

            Assert.True(result);
        }

        [Theory]
        [InlineData("t@m.c")]
        [InlineData("test@mail")]
        [InlineData("mail.com")]
        [InlineData("t@mail.com")]
        [InlineData("test@m.com")]
        [InlineData("test@mail.c")]
        public void ShouldNotBeAbleToRegisterInvalidEmail(string email)
        {
            var result = SignUpValidator.CheckEmail(email);

            Assert.False(result);
        }

        [Fact]
        public void ShouldBeAbleToRegisterValidPassword()
        {
            var result = SignUpValidator.CheckPassword("Password123");

            Assert.True(result.Success);
        }

        [Theory]
        [InlineData("password123")]
        [InlineData("Password")]
        [InlineData("Pass")]
        public void ShouldNotBeAbleToRegisterInvalidPassword(string password)
        {
            var result = SignUpValidator.CheckPassword(password);

            Assert.False(result.Success);
        }

        [Fact]
        public void ShouldBeAbleToRegisterWhenPasswordMatch()
        {
            var result = SignUpValidator.CheckRepeatPassword("Password123", "Password123");

            Assert.True(result);
        }

        [Fact]
        public void ShouldNotBeAbleToRegisterWithNonMatchingPassword()
        {
            var result = SignUpValidator.CheckRepeatPassword("Password123", "Password456");

            Assert.False(result);
        }
    }
}
