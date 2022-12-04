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

        public UserDto ProfileUser { get; set; } = new();

        public UserDto LoggedInUser { get; set; } = new();

        public List<PostDto> Posts { get; set; } = new();

        public bool IsLoading { get; set; }

        public bool ShowDialog { get; set; }

        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        private async Task PostOnWall()
        {
            PostModel.WallOwner = ProfileUser.Username;
            PostModel.Username = LoggedInUser.Username;
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
                MessageModel.Sender = LoggedInUser.Username;
                MessageModel.Reciever = ProfileUser.Username;

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

            var loggedInUserUsername = await JSRuntime.InvokeAsync<string>("getUser");

            ProfileUser = await _proxy.GetUserByUsername(Username);
            LoggedInUser = await _proxy.GetUserByUsername(loggedInUserUsername);
            Posts = await _proxy.GetPostsByWallOwner(Username);
            IsLoading = false;
        }
    }
}
