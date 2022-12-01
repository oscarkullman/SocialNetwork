using Frontend.Models;
using Newtonsoft.Json;
using SocialNetwork.Classes;
using SocialNetwork.Classes.Account;
using SocialNetwork.Classes.Post;
using System.Text;
using WebAPI.DTO;

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
            var bodyContent = new StringContent(JsonConvert.SerializeObject(logInModel), Encoding.UTF8, "application/json");

            var result = await _client.PostAsync("api/account/LogIn", bodyContent);

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

        #endregion

        #region Post

        public async Task<StatusCodeHandler> CreateNewPost(PostModel post)
        {
            var bodyContent = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

            var result = await _client.PostAsync("api/post/CreateNewPost", bodyContent);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<StatusCodeHandler>(content);

                return data;
            }

            return new StatusCodeHandler(400, "Something went wrong when posting.");
        }

        public async Task<List<PostDto>> GetPostsByUsername(string username)
        {
            var result = await _client.GetAsync($"api/post/GetPostsByUsername?Username={username}&Sort=createddescending");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<PostDto>>(content);

                return data;
            }

            return new List<PostDto>();
        }

        #endregion

        #region User

        public async Task<List<UserDto>> SearchUsersByUsername(string username)
        {
            var result = await _client.GetAsync($"api/user/GetAllUsers?Username={username}");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<UserDto>>(content);

                return data;
            }

            return new List<UserDto>();
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var result = await _client.GetAsync($"api/user/GetUserByUsername/{username}");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UserDto>(content);

                return data;
            }

            return new UserDto();
        }

        #endregion
    }
}