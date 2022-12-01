using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.WebApi.Proxy;
using WebAPI.DTO;

namespace Frontend.Pages
{
    partial class Profile
    {
        [Parameter]
        public string Username { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public UserDto User { get; set; } = new();

        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        protected override async Task OnInitializedAsync()
        {
            User = await _proxy.GetUserByUsername(Username);

            var authorized = await JSRuntime.InvokeAsync<bool>("isAuthenticated");
            if (!authorized) NavigationManager.NavigateTo("/");
        }
    }
}
