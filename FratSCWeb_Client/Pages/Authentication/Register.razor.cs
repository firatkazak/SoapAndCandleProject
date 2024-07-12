using FratSCWeb_Client.Service.IService;
using FratSCWeb_Models;
using Microsoft.AspNetCore.Components;

namespace FratSCWeb_Client.Pages.Authentication
{
    public partial class Register
    {
        private SignUpRequestDTO SignUpRequest = new();
        public bool IsProcessing { get; set; } = false;
        public bool ShowRegistrationErrors { get; set; }
        public IEnumerable<string> Errors { get; set; }

        [Inject]
        public IAuthenticationService _authService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        private async Task RegisterUser()
        {
            ShowRegistrationErrors = false;
            IsProcessing = true;
            var result = await _authService.RegisterUser(SignUpRequest);
            if (result.IsRegisterationSuccessful)
            {
                _navigationManager.NavigateTo("/login");
            }
            else
            {
                Errors = result.Errors;
                ShowRegistrationErrors = true;
            }
            IsProcessing = false;
        }
    }
}
