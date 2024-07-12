using Microsoft.AspNetCore.Identity;

namespace FratSCWeb_DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
