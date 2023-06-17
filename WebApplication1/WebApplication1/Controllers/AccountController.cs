using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Dtos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse>> Login(UserLoginDto dto)
        {
            if (!ModelState.IsValid) { return BadRequest(new ApiResponse(400, false, ModelState)); }

            return Ok(await _accountService.LoginUser(dto));
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> RegisterUser(UserRegisterDto dto)
        {
            if (!ModelState.IsValid) { return BadRequest(new ApiResponse(400, false, ModelState)); }
            
            return Ok(await _accountService.RegisterUser(dto));
        }

        [HttpGet("ResetPassword")]
        public async Task<ActionResult<ApiResponse>> GetResetPasswordToken([EmailAddress] string Email)
        {
            if (!ModelState.IsValid) { return BadRequest(new ApiResponse(400, false, "Not Valid Email")); }

            return Ok(await _accountService.GetResetPasswordToken(Email));

        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult<ApiResponse>> ResetPassword(RestPasswordDto RestPasswordDto)
        {
            if (!ModelState.IsValid) { return BadRequest(new ApiResponse(400, false, ModelState)); }

            return Ok(await _accountService.ResetPassword(RestPasswordDto));

        }

        [Authorize]
        [HttpPost("test")]
        public async Task<ActionResult<ApiResponse>> test()
        {
            return Ok(new { Msg="hello" } );
        }


    }   
}
