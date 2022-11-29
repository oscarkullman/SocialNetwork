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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private SocialNetworkWebApiProxy _proxy = new SocialNetworkWebApiProxy();

        public RegisterModel RegisterModel { get; set; } = new();

        public SignUpValidationResult RegistrationValidation { get; set; } = new();

        public bool IsLoading { get; set; }

        private async Task RegisterUser()
        {
            RegistrationValidation = SignUpValidator.Validate(RegisterModel);

            if (RegistrationValidation.Success)
            {
                IsLoading = true;
                var result = await _proxy.RegisterNewUser(RegisterModel);
                IsLoading = false;

                if (result.IsSuccessful)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    await JSRuntime.InvokeVoidAsync("alertMessage", result.Errors.Aggregate("", (errors, error) => errors = errors + $"- {error}\n"));
                }
            }
        }
    }
}
