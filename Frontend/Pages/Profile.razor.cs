using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.Classes.Models;
using SocialNetwork.Classes.Post;
using SocialNetwork.Classes.User;
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

        public int UserFollowersCount { get; set; }

        public List<PostDto> Posts { get; set; } = new();

        public bool IsLoading { get; set; }

        public bool ShowMessageDialog { get; set; }

        public bool ShowFollowingsDialog { get; set; }

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
            ShowMessageDialog = !ShowMessageDialog;
        }

        private void ToggleFollowingsDialog()
        {
            ShowFollowingsDialog = !ShowFollowingsDialog;
        }

        private async Task FollowUser()
        {
            var followModel = new FollowModel
            {
                UserFollowing = LoggedInUser.Username,
                UserToFollow = ProfileUser.Username
            };

            var result = await _proxy.AddNewFollow(followModel);

            if (!result.IsSuccessful)
            {
                await JSRuntime.InvokeVoidAsync("alertMessage", $"Something went wrong when trying to follow {ProfileUser.Username}");
                return;
            }

            UserFollowersCount++;
            LoggedInUser.Follows.Add(result.Content);
            StateHasChanged();
        }

        private async Task UnFollowUser()
        {
            var follow = LoggedInUser.Follows.FirstOrDefault(x => x.UserId == LoggedInUser.Id && x.Username == ProfileUser.Username);

            var result = await _proxy.RemoveFollowing(follow);

            if (!result.IsSuccessful)
            {
                await JSRuntime.InvokeVoidAsync("alertMessage", $"Something went wrong when trying to unfollow {ProfileUser.Username}");
                return;
            }

            UserFollowersCount--;
            LoggedInUser.Follows.Remove(follow);
            StateHasChanged();
        }

        private async Task SendMessage()
        {
            MessageModel.Sender = LoggedInUser.Username;
            MessageModel.Reciever = ProfileUser.Username;

            var result = await _proxy.SendMessage(MessageModel);

            if (result.IsSuccessful)
            {
                ToggleMessageDialog();
                MessageModel = new();
                await JSRuntime.InvokeVoidAsync("alertMessage", $"Your message to {ProfileUser.Username} was sent successfully.");
                return;
            }

            await JSRuntime.InvokeVoidAsync("alertMessage", "An error occured when sending direct message.");
        }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            var authorized = await JSRuntime.InvokeAsync<bool>("isAuthenticated");
            if (!authorized) NavigationManager.NavigateTo("/");

            var loggedInUserUsername = await JSRuntime.InvokeAsync<string>("getUser");

            ProfileUser = await _proxy.GetUserByUsername(Username);
            LoggedInUser = await _proxy.GetUserByUsername(loggedInUserUsername);
            UserFollowersCount = await _proxy.GetUserFollowersCount(Username);

            Posts = await _proxy.GetPostsByWallOwner(Username);
            IsLoading = false;
        }
    }
}
