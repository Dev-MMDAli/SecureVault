using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SecureVault.Data;
using Microsoft.AspNetCore.Mvc;
using SecureVault.DTOs;
using SecureVault.Interfaces;
using SecureVault.Models;
using SecureVault.Services;
using System.Security.Claims;

namespace SecureVault.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (int.TryParse(userIdClaim.Value, out int userIdResult))
            {
                return userIdResult;
            }
            throw new UnauthorizedAccessException("invalid userid in token");

        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = GetCurrentUserId();
            var result = await _passwordService.GetAllAsync(userId);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePasswordDto dto)
        {
            var userId = GetCurrentUserId();
            var result = await _passwordService.AddAsync(dto,userId);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = GetCurrentUserId();
            var result = await _passwordService.GetByIdAsync(id,userId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] PatchPasswordDto dto)
        {
            var userId = GetCurrentUserId();

            var result = await _passwordService.PatchAsync(id,userId, dto);
            if (result == null)
            {
                return Forbid();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetCurrentUserId();

            var result = await _passwordService.DeleteAsync(id, userId);

            if (!result)
            {
                return Forbid();
            }
            return NoContent();
        }
    }
}
