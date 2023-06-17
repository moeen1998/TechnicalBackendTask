using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class RestPasswordDto
    {
        
        [MinLength(8)]
        public string Password { get; set; }
        
        [Compare("Password")]
        public string Confirm { get; set; }
        
        public string ResetPasswordToken { get; set; }
    }
}
