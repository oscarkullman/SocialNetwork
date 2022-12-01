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

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        public LogInModel LogInModel { get; set; } = new();

        public bool LogInValidationSuccessful { get; set; } = true;

        public bool IsLoading { get; set; }

        private async Task LogInUser()
        {
            LogInValidationSuccessful = SignInValidator.Validate(LogInModel);

            if (LogInValidationSuccessful)
            {
                IsLoading = true;
                var result = await _proxy.LogInUser(LogInModel);
                IsLoading = false;
                
                if (result.IsSuccessful)
                {
                    await JSRuntime.InvokeVoidAsync("logIn", LogInModel.Username);
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    LogInValidationSuccessful = false;
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var authorized = await JSRuntime.InvokeAsync<bool>("isAuthenticated");
            if (authorized) NavigationManager.NavigateTo("/");
        }
    }

}
