using Microsoft.AspNetCore.Identity;

namespace AcmeWebsite
{
    public class AuthenticationConfig
    {
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
