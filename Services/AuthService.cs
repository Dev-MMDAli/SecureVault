using SecureVault.DTOs;
using SecureVault.Interfaces;
using SecureVault.Models;

namespace SecureVault.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> RegisterAsync(RegisterDto dto)
        {
            var findUserByEmail= await _userRepository.GetByEmailAsync(dto.Email);
            if (findUserByEmail!= null)
            {
                return null;
            }
            User user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                UserName = dto.UserName,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsEmailConfirmed = false,
                ModifiedDate = null

            };


             await _userRepository.AddAsync(user);
             await _userRepository.SaveChangesAsync();
             return user;
        }
        public async Task<User?> LoginAsync(LoginDto dto)
        {
            var result = await _userRepository.GetByEmailAsync(dto.Email);

            if (result == null)
                return null;

            if (!result.IsActive)
                return null;
                
            
            bool isPasswordVerify = BCrypt.Net.BCrypt.Verify(dto.Password, result.Password);
            if (!isPasswordVerify)
                return null;

            return result;


        }
    }
}
