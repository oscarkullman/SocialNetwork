using Frontend.Models;
using Microsoft.AspNetCore.Components;
using SocialNetwork.Classes;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Pages
{
    partial class Index
    {
        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        private StatusCodeHandler _isAuthorized = new();

        private async Task OninitializedAsync()
        {
            _isAuthorized = await _proxy.CheckAuthorization();
        }
    }
}