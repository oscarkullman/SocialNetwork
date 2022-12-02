using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.Classes.Post;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Components
{
    partial class Wall
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        public PostModel PostModel { get; set; } = new();

        public List<PostDto> Posts { get; set; } = new();

        public bool IsLoading { get; set; }

        private string? _loggedInUser;

        private async Task PublishPost()
        {
            PostModel.WallOwner = _loggedInUser;
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

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            _loggedInUser = await JSRuntime.InvokeAsync<string>("getUser");

            Posts = await _proxy.GetPostsByWallOwner(_loggedInUser);
            IsLoading = false;
        }
    }
}
