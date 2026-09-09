using Microsoft.EntityFrameworkCore;
using SecureVault.Data;
using SecureVault.Interfaces;
using SecureVault.Models;
namespace SecureVault.Repositories
{
    public class UserRepository:IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context=context;
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            var user= await _context.Users.FirstOrDefaultAsync(u=>u.Email == email);
            return user;
        }
        public async Task AddAsync(User user)
        { 
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

    }
}
