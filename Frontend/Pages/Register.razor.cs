using Frontend.Models;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Pages
{
    partial class Register
    {
        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        public RegisterModel RegisterModel { get; set; } = new();

        public bool IsLoading { get; set; }

        private async Task RegisterUser()
        {
            IsLoading = !IsLoading;

            await _proxy.RegisterNewUser(RegisterModel);
            RegisterModel = new();

            IsLoading = false;
        }
    }
}
