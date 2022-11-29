using SocialNetwork.Classes.Account;
using SocialNetwork.Classes.Frontend;

namespace Frontend.Pages
{
    partial class Login
    {
        public LogInModel LogInModel { get; set; } = new();

        public SignInValidator LogInValidation { get; set; } = new();

        
    }
}
