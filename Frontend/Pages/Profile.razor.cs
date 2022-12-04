using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.Classes.Models;
using SocialNetwork.Classes.Post;
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

        public PostModel PostModel { get; set; } = new();

        public MessageModel MessageModel { get; set; } = new();

        public UserDto User { get; set; } = new();

        public List<PostDto> Posts { get; set; } = new();

        public bool IsLoading { get; set; }

        public bool ShowDialog { get; set; }

        private string? _loggedInUser;

        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        private async Task PostOnWall()
        {
            PostModel.WallOwner = User.Username;
            PostModel.Username = _loggedInUser;
            var result = await _proxy.CreateNewPost(PostModel);

            if (result.IsSuccessful)
            {
                PostModel = new PostModel();
                Posts.Insert(0, result.Content);
                return;
            }

            await JSRuntime.InvokeVoidAsync("alertMessage", "Oops, something went wrong!");
        }

        private void GoToProfile(string username)
        {
            NavigationManager.NavigateTo($"/profile/{username}", true);
        }


        private void ToggleMessageDialog()
        {
            ShowDialog = !ShowDialog;
        }

        private async Task SendMessage()
        {
            if (!string.IsNullOrEmpty(MessageModel.Content))
            {
                MessageModel.Sender = _loggedInUser;
                MessageModel.Reciever = User.Username;

                var result = await _proxy.SendMessage(MessageModel);

                if (result.IsSuccessful)
                {
                    ToggleMessageDialog();
                    MessageModel = new();
                    return;
                }

                await JSRuntime.InvokeVoidAsync("alertMessage", "An error occured when sending direct message.");
            }
        }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            var authorized = await JSRuntime.InvokeAsync<bool>("isAuthenticated");
            if (!authorized) NavigationManager.NavigateTo("/");

            _loggedInUser = await JSRuntime.InvokeAsync<string>("getUser");
            User = await _proxy.GetUserByUsername(Username);
            Posts = await _proxy.GetPostsByWallOwner(Username);
            IsLoading = false;
        }
    }
}
