using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureVault.DTOs;
using SecureVault.Interfaces;
using SecureVault.Services;

namespace SecureVault.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(IAuthService authService,JwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto dto)
        {
            var user = await _authService.RegisterAsync(dto);
            if (user == null)
            {
                return BadRequest();
            }

            return Created();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginDto dto)
        {
           var user= await _authService.LoginAsync(dto);
           if (user==null)
           {
               return Unauthorized();
           }

           var token= _jwtService.GenerateToken(user);
           return Ok(new { Token = token});
        }

    }
}
