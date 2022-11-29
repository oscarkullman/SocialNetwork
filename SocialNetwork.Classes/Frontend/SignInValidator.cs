using SocialNetwork.Classes.Account;

namespace SocialNetwork.Classes.Frontend
{
    public class SignInValidator
    {
        public static bool CheckUsername(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                if (username.Length < 5) 
                    return false;
            } else { return false; }
            
            return true;
        }

        public static bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return true;
        }
        
        public static bool Validate(LogInModel loginModel)
        {
            if (!CheckUsername(loginModel.Username))
            {
                return false;
            }

            if (!CheckPassword(loginModel.Password))
            {
                return false;
            }

            return true;
        }
    }
}
