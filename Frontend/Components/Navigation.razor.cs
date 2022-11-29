using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Frontend.Components
{
    partial class Navigation
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private bool _isAuthenticated;

        protected override async Task OnInitializedAsync()
        {
            _isAuthenticated = await JSRuntime.InvokeAsync<bool>("isAuthenticated");
        }

        private async Task LogOut()
        {
            await JSRuntime.InvokeVoidAsync("logOut");
            NavigationManager.NavigateTo("/login", true);
        }
    }
}
