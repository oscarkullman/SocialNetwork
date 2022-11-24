using Frontend.Models;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Pages
{
    partial class Register
    {
        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        public RegisterModel RegisterModel { get; set; } = new();

        private async Task RegisterUser()
        {
            await _proxy.RegisterNewUser(RegisterModel);
        }
    }
}
