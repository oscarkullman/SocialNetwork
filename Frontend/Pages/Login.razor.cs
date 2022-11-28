using SocialNetwork.Classes.Account;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Pages
{
    partial class Login
    {
        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

      public LogInModel LogInModel { get; set; } = new();


        private async Task LoginUser()
        {

           await _proxy.LogInUser(LogInModel);
           LogInModel = new();

        }
    }

}
