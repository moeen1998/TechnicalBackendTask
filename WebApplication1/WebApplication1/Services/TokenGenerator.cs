using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TokenGenerator
    {
        private readonly IConfiguration config;
        private readonly UserManager<User> userManager;
        private readonly SymmetricSecurityKey key;

        public TokenGenerator(IConfiguration _config, UserManager<User> _userManager)
        {
            this.config = _config;
            userManager = _userManager;
            key = new(Encoding.UTF8.GetBytes(config["JWT:Key"]));
        }

        public async Task<string> GenerateToken(User user, string Id)
        {
            List<Claim> claims = new()
            {
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, Id),
                new(ClaimTypes.Name, user.UserName),
            };

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken mytoken = new JwtSecurityToken(
                expires : DateTime.UtcNow.AddDays(double.Parse(config["JWT:ExpInDayes"])),
                issuer : config["JWT:Issuer"],
                audience : config["JWT:Audience"],
                signingCredentials : credentials,
                claims : claims
            );

            var token = new JwtSecurityTokenHandler().WriteToken(mytoken);

            return token;

        }
    }
}
