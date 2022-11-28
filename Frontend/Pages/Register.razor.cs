using Frontend.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.Classes.Frontend;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Pages
{
    partial class Register
    {
        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        public RegisterModel RegisterModel { get; set; } = new();

        public SignUpValidationResult ValidationResult { get; set; } = new();

        public bool IsLoading { get; set; }

        private async Task RegisterUser()
        {
            await JSRuntime.InvokeVoidAsync("registrationAlert", "Registration alert message test");
            
            //IsLoading = !IsLoading;

            //await _proxy.RegisterNewUser(RegisterModel);
            //RegisterModel = new();

            //IsLoading = false;
        }
    }
}
