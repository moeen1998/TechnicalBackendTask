using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class UserRegisterDto
    {
        
        public string Name { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        [MinLength(8)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
