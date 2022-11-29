using Frontend.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.Classes;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Pages
{
    partial class Index
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private bool _isAuthenticated = new();

        protected override async Task OnInitializedAsync()
        {
            _isAuthenticated = await JSRuntime.InvokeAsync<bool>("isAuthenticated");
        }
    }
}