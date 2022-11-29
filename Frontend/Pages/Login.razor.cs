using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Account;
using SocialNetwork.Classes.Frontend;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Pages
{
    partial class Login
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public NavigationManager NavigationManager { get; set; }
        
        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        public LogInModel LogInModel { get; set; } = new();

        public bool LogInValidationSuccessful { get; set; } = true;

        private async Task LogInUser()
        {
            LogInValidationSuccessful = SignInValidator.Validate(LogInModel);

            if (LogInValidationSuccessful)
            {
                var result = await _proxy.LogInUser(LogInModel);
                
                if (result.IsSuccessful)
                {
                    NavigationManager.NavigateTo("/");
                }

                await JSRuntime.InvokeVoidAsync("alertMessage", result.Message);
            }
        }
    }

}
