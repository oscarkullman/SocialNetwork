using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.Classes.Models;

namespace Frontend.Components
{
    partial class Navigation
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public SearchModel SearchModel { get; set; } = new();

        private bool _isAuthenticated;

        private string _loggedInUser;

        private void SearchByUsername()
        {
            if (!string.IsNullOrEmpty(SearchModel.Search))
            {
                var url = $"/search/{SearchModel.Search}";
                NavigationManager.NavigateTo(url, true);
            }
        }

        private void GoToProfile(string username)
        {
            NavigationManager.NavigateTo($"/profile/{username}", true);
        }

        private async Task LogOut()
        {
            await JSRuntime.InvokeVoidAsync("logOut");
            NavigationManager.NavigateTo("/login", true);
        }

        protected override async Task OnInitializedAsync()
        {
            _isAuthenticated = await JSRuntime.InvokeAsync<bool>("isAuthenticated");
            _loggedInUser = await JSRuntime.InvokeAsync<string>("getUser");
        }
    }
}
