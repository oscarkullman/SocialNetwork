using Frontend.Models;
using Newtonsoft.Json;
using SocialNetwork.Classes;
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

        public async Task<StatusCodeHandler> LogInUser(LogInModel logInModel)
        {
            var request = new HttpRequestMessage();
            request.Content = new StringContent(JsonConvert.SerializeObject(logInModel), Encoding.UTF8, "application/json");

            var result = await _client.PostAsync("api/account/LogIn", request.Content);

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<StatusCodeHandler>(data);

                return content;
            }

            return new StatusCodeHandler(400, "An error occured while trying to log in.");
        }
            
        public async Task<StatusCodeHandler> RegisterNewUser(RegisterModel registerModel)
        {
            var request = new HttpRequestMessage();
            request.Content = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");

            var result = await _client.PostAsync("api/account/Register", request.Content);

            try
            {
                var data = await result.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<StatusCodeHandler>(data);

                return content;
            }
            catch (Exception e)
            {
                return new StatusCodeHandler(500, e.Message);
            }
        }

        public async Task<StatusCodeHandler> LogOutUser()
        {
            var result = await _client.GetAsync("api/account/LogOut");

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<StatusCodeHandler>(data);

                return content;
            }

            return new StatusCodeHandler(400, "An error occured while trying to log out the user.");
        }

        public async Task<StatusCodeHandler> CheckAuthorization()
        {
            var result = await _client.GetAsync("api/account/CheckAuthorization");

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<StatusCodeHandler>(data);

                return content;
            }

            return new StatusCodeHandler(400, "An error occured while checking authorization.");
        }

        #endregion
    }
}