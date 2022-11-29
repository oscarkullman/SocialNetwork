using Frontend.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SocialNetwork.Classes.Frontend;
using SocialNetwork.WebApi.Proxy;

namespace Frontend.Pages
{
    partial class Register
    {
        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        public RegisterModel RegisterModel { get; set; } = new();

        public SignUpValidationResult RegistrationValidation { get; set; } = new();

        public bool IsLoading { get; set; }

        private async Task RegisterUser()
        {
            RegistrationValidation = SignUpValidator.Validate(RegisterModel);

            if (RegistrationValidation.Success)
            {
                await JSRuntime.InvokeVoidAsync("registrationAlert", $"Registration of user {RegisterModel.Username} was successful!");
                RegistrationValidation = new SignUpValidationResult();
                RegisterModel = new RegisterModel();

                //IsLoading = !IsLoading;
                //var result = await _proxy.RegisterNewUser(RegisterModel);
                //IsLoading = false;

                //if (result.IsSuccessful)
                //{
                //    RegisterModel = new();
                //}

                //await JSRuntime.InvokeVoidAsync("registrationAlert", result.Message);
            }
        }
    }
}
