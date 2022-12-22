using CaseProject.Business.Abstract;
using CaseProject.Entity.Dto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;

namespace CaseProject.MVC.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (!userToLogin.IsSuccess)
            {
                ViewBag.message = userToLogin.Message;
                return View();
            }
            //var token = new JwtSecurityToken(jwtEncodedString: idtoken);

            var result = await _authService.CreateAccessToken(userToLogin.Data);
            if (result.IsSuccess)
            {
                HttpContext.Session.SetString("Token", result.Data.Token);
                Response.Cookies.Append("JwtToken", result.Data.Token);
                return RedirectToAction("Index", "Home");
                //return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
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

        public async Task<IActionResult> LogOut()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Session");
            return RedirectToAction("Login", "Auth");
        }
    }
}
