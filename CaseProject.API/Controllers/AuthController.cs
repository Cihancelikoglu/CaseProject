using CaseProject.Business.Abstract;
using CaseProject.Data.Abstract;
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

        [HttpGet("getbyid")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _authService.GetByIdAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
