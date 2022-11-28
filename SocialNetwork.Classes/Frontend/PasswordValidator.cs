namespace SocialNetwork.Classes.Frontend
{
    public class PasswordValidator
    {
        public static bool CheckLength(string? password)
        {
            if ((password ?? "").Length < 6) return false;
            
            return true;
        }

        public static bool CheckForUpperCase(string? password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (char.IsUpper(password[i])) return true;
                }
            }
            
            return false;
        }

        public static bool CheckForNumeric(string? password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (char.IsDigit(password[i])) return true;
                }
            }

            return false;
        }

        public static PasswordValidationResult Validate(string? password)
        {
            var error = "Must be at least 6 characters long and contain at least 1 upper case and numeric character.";

            if (!CheckLength(password) || !CheckForUpperCase(password) || !CheckForNumeric(password))
            {
                return new PasswordValidationResult(error);
            }

            return new PasswordValidationResult("Password validation was successful.", true);
        }
    }
}
