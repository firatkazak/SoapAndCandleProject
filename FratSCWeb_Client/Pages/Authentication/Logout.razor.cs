using FratSCWeb_Client.Service.IService;
using Microsoft.AspNetCore.Components;

namespace FratSCWeb_Client.Pages.Authentication
{
    public partial class Logout
    {
        [Inject]
        public IAuthenticationService _authService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await _authService.LogOut();
            _navigationManager.NavigateTo("/");
        }
    }
}
