using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class User:IdentityUser
    {
        public string? ResetPasswordToken { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
