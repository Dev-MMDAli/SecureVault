using SecureVault.DTOs;
using SecureVault.Models;

namespace SecureVault.Interfaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(RegisterDto dto);
        Task<User?> LoginAsync(LoginDto dto);

    }
}
