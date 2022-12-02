using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.Classes.Message;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Pages
{
    partial class Messages
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<MessageDto> UserMessages { get; set; } = new();

        public MessageDto CurrentMessage { get; set; } = new();

        public bool IsLoading { get; set; }

        private string _loggedInUser;

        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        private void SetCurrentMessage(MessageDto message)
        {
            CurrentMessage = message;
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            var authorized = await JSRuntime.InvokeAsync<bool>("isAuthenticated");
            if (!authorized) NavigationManager.NavigateTo("/");

            _loggedInUser = await JSRuntime.InvokeAsync<string>("getUser");
            UserMessages = await _proxy.GetMessagesByUsername(_loggedInUser);
            IsLoading = false;
        }
    }
}
