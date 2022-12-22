using CaseProject.Business.Abstract;
using CaseProject.Core.Utilities.Result;
using CaseProject.Data.Abstract;
using CaseProject.Entity.Dto;
using CaseProject.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpGet("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = await _authService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = await _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = await _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (registerResult.IsSuccess)
            {
                return Ok(registerResult.Data);
            }

            return BadRequest(registerResult.Message);
        }
    }
}
