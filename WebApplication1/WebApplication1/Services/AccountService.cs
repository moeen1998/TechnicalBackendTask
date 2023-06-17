using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AccountService 
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private TokenGenerator _tokenGenerator;
        private EmailService _emailService;

        public AccountService(SignInManager<User> signInManager,UserManager<User> userManager, TokenGenerator tokenGenerator,EmailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
            _emailService = emailService;
        }
        public async Task<ApiResponse> LoginUser (UserLoginDto dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null) { return new ApiResponse(404, false, null, "User not found"); }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded) { return new ApiResponse(401, false, null, "Invalid password"); }

            return new ApiResponse(200, true, new UserDto
            {
                Name = $"{user.UserName}",
                Email = user.Email,
                Token = await _tokenGenerator.GenerateToken(user, user.Id),
            });
        }

        public async Task<ApiResponse> RegisterUser(UserRegisterDto userDto)
        {
            if(userDto.Password != userDto.ConfirmPassword) { return new ApiResponse(400, false, null,"The password And Confirm Password Doesn't Match"); }

            User user = new() { Email = userDto.Email,UserName = userDto.Name };
            
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded) { return new ApiResponse(400, false, result.Errors); }

            return new ApiResponse(200, true, new UserDto
            {
                Name = $"{user.UserName}",
                Email = user.Email,
                Token = await _tokenGenerator.GenerateToken(user, user.Id),
            });
        }
        public async Task<ApiResponse> GetResetPasswordToken([EmailAddress] string Email)
        {
            User user = await _userManager.FindByEmailAsync(Email);
            if(user == null)
                return new ApiResponse(400, false, null, "Wrong Email");
            
            user.ResetPasswordToken = GeneratePasswordToken();

            user.ExpirationDate = DateTime.Now.AddHours(1);
            IdentityResult result =  await _userManager.UpdateAsync(user);
            
            if (result.Succeeded)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////
                string Emailbody = GetEmailBody(user.ResetPasswordToken);

                _emailService.SendEmail(user.Email, Emailbody);

                ////////////////////////////////////////// send Email ////////////////////////////
                return new ApiResponse( 200, true, new { RestPasswordToken = user.ResetPasswordToken}, "Check Your Email" );
            }
            else
            {
                return new ApiResponse(400, false, null, "Try Agin Later");
            }
        }

        public async Task<ApiResponse> ResetPassword(RestPasswordDto RestPasswordDto)
        {
            User user = _userManager.Users.FirstOrDefault(u => u.ResetPasswordToken == RestPasswordDto.ResetPasswordToken);

            if(user == null || user.ExpirationDate < DateTime.Now)
            {
                user.ResetPasswordToken = "";
                user.ExpirationDate = null;
                return new ApiResponse(400, false, null, "Invalid Token, Try To Reset Your Password Agine");
            }

            IdentityResult result = await _userManager.RemovePasswordAsync(user);

            if(result.Succeeded)
                result = await _userManager.AddPasswordAsync(user,RestPasswordDto.Password);

            if (!result.Succeeded)
                return new ApiResponse(400, false, null, "Try Agin Later");

            user.ResetPasswordToken = "";
            user.ExpirationDate = null;
            
            return new ApiResponse(200, true, new { Password = RestPasswordDto.Password }, "Password Changed");
        }

        private string? GeneratePasswordToken()
        {
            string result = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
            User user = _userManager.Users.FirstOrDefault(u => u.ResetPasswordToken == result);
            if (user == null)
                return result;
            return GeneratePasswordToken();

        }

        private string GetEmailBody(string token)
        {
            return $"<h2>Reset Password</h2><input hidden='hidden' id='ResetPasswordToken' value='{token}' />  Enter Your New Password: <input id='Password' type='password' />   Confirm Your Password: <input id='Confirm' type='password' />    <button onclick='submit()'>Update Password</button> <script>   function submit(){{   var Password = document.getElementById('Password').value;        var Confirm = document.getElementById('Confirm').value;        var ResetPasswordToken = document.getElementById(ResetPasswordToken).value;        fetch('http://localhost:5251/api/Account/ResetPassword', {{            method: 'POST',            body: JSON.stringify({{Password, Confirm , ResetPasswordToken}}),            headers: {{               'Content-type': 'application/json; charset=UTF-8'            }}       }});    }};</script>";
            
            //return $"<h2>Reset Password</h2>\r\n <form method='post' enctype='multipart/form-data' action='http://localhost:5251/api/Account/ResetPassword'> <input hidden='hidden' name='ResetPasswordToken' value='{token}'/>\r\n  Enter Your New Password: <input name='Password' type='password'/>\r\n  Confirm Your Password: <input name='Confirm' type='password'/>\r\n  <button type='submit'>Update Password</button>\r\n</form>";
            
            //return $"<a href='http://localhost:5251/api/Account/ResetPassword?ResetPasswordToken={token}'>Reset Password</a>";
        }
    }
}
