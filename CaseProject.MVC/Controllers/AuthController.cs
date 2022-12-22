using CaseProject.Business.Abstract;
using CaseProject.Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.MVC.Controllers
{
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
            return RedirectToAction("Index", "Home");
            //var result = _authService.CreateAccessToken(userToLogin.Data);
            //if (userToLogin.IsSuccess)
            //{
            //    return Ok(result);
            //}

            //return BadRequest(result.Message);
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
            //var result = _authService.CreateAccessToken(registerResult.Data);
            if (registerResult.IsSuccess)
            {
                return Ok(registerResult.Data);
            }

            return BadRequest(registerResult.Message);
        }
    }
}
