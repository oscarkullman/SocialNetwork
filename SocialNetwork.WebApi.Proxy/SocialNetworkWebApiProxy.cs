using Frontend.Models;
using Newtonsoft.Json;
using SocialNetwork.Classes.Account;
using System.Text;

namespace SocialNetwork.WebApi.Proxy
{
    public class SocialNetworkWebApiProxy
    {
        HttpClient _client = new HttpClient();

        public SocialNetworkWebApiProxy()
        {
            _client.BaseAddress = new Uri("https://localhost:7068/");
        }

        #region Account

        public async Task LoginUser(LoginModel loginModel)
        {

        }
            
        public async Task RegisterNewUser(RegisterModel registerModel)
        {
            var request = new HttpRequestMessage();
            request.Content = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");

            await _client.PostAsync("api/account/Register", request.Content);
        }

        #endregion

        #region User

        #endregion
    }
}