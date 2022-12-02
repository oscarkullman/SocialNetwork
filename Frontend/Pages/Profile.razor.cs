using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        public UserDto User { get; set; } = new();

        public List<PostDto> Posts { get; set; } = new();

        public bool IsLoading { get; set; }

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
