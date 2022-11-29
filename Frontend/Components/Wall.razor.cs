using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Frontend.Components
{
    partial class Wall
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private string _username;

        protected override async Task OnInitializedAsync()
        {
            _username = await JSRuntime.InvokeAsync<string>("getUser");
        }
    }
}
