using Frontend.Models;
using System.Text.RegularExpressions;

namespace SocialNetwork.Classes.Frontend
{
    public class SignUpValidator
    {
        public static bool CheckFirstName(string? firstName)
        {
            if (!string.IsNullOrEmpty(firstName))
            {
                if (firstName.Length < 2) return false;
                
                for (int i = 0; i < firstName.Length; i++)
                {
                    if (!char.IsLetter(firstName[i])) return false;
                }
            }
            else { return false; }

            return true;
        }

        public static bool CheckLastName(string? lastName)
        {
            if (!string.IsNullOrEmpty(lastName))
            {
                if (lastName.Length < 2) return false;

                for (int i = 0; i < lastName.Length; i++)
                {
                    if (!char.IsLetter(lastName[i])) return false;
                }
            }
            else { return false; }

            return true;
        }

        public static bool CheckUsername(string? username)
        {
            if (string.IsNullOrEmpty(username) ||
                !Regex.IsMatch(username, @"^[A-Öa-ö0-9_]{5,}$"))
                return false;

            return true;
        }

        public static bool CheckEmail(string? email)
        {
            if (string.IsNullOrEmpty(email) ||
                !Regex.IsMatch(email, @"^[A-Za-z0-9_.-]{2,}@[A-Za-z0-9]{2,}\.[A-Za-z]{2,}$"))
                return false;

            return true;
        }

        public static PasswordValidationResult CheckPassword(string? password)
        {
            return PasswordValidator.Validate(password);
        }

        public static bool CheckRepeatPassword(string? password, string? repeatPassword)
        {
            if (repeatPassword != password) return false;

            return true;
        }

        public static SignUpValidationResult Validate(RegisterModel registerModel)
        {
            var validationResult = new SignUpValidationResult();
            var success = true;

            if (!CheckFirstName(registerModel.FirstName))
            {
                validationResult.FirstName = "Needs to be at least 2 characters long without any numbers or special characters.";
                success = false;
            }

            if (!CheckLastName(registerModel.LastName))
            {
                validationResult.LastName = "Needs to be at least 2 characters long without any numbers or special characters.";
                success = false;
            }

            if (!CheckUsername(registerModel.Username))
            {
                validationResult.Username = "Needs to be at least 5 characters long without any special characters.";
                success = false;
            }

            if (!CheckEmail(registerModel.Email))
            {
                validationResult.Email = "Invalid email pattern.";
                success = false;
            }

            if (!CheckRepeatPassword(registerModel.Password, registerModel.RepeatPassword))
            {
                validationResult.RepeatPassword = "Passwords doesn't match.";
                success = false;
            }

            var passwordValidation = CheckPassword(registerModel.Password);

            if (!passwordValidation.Success)
            {
                validationResult.Password = passwordValidation.Message;
                validationResult.RepeatPassword = null;
                success = false;
            }

            validationResult.Success = success;

            return validationResult;
        }
    }
}
