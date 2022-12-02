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

        private string _username;

        private async Task PublishPost()
        {
            PostModel.Username = _username;
            var result = await _proxy.CreateNewPost(PostModel);

            if (result.IsSuccessful)
            {
                PostModel = new PostModel();

                Posts = await _proxy.GetPostsByUsername(_username);

                return;
            }

            await JSRuntime.InvokeVoidAsync("alertMessage", "Oops, something went wrong!");
        }

        protected override async Task OnInitializedAsync()
        {
            _username = await JSRuntime.InvokeAsync<string>("getUser");

            Posts = await _proxy.GetPostsByUsername(_username);
        }
    }
}
