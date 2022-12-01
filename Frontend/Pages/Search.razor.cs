using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.WebApi.Proxy;
using WebAPI.DTO;

namespace Frontend.Pages
{
    partial class Search
    {
        [Parameter]
        public string UserSearch { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<UserDto> Users { get; set; } = new();

        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        protected override async Task OnInitializedAsync()
        {
            Users = await _proxy.SearchUsersByUsername(UserSearch);

            var authorized = await JSRuntime.InvokeAsync<bool>("isAuthenticated");
            if (!authorized) NavigationManager.NavigateTo("/");
        }
    }
}
