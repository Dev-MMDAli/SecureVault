using Microsoft.EntityFrameworkCore;
using SecureVault.Data;
using SecureVault.Interfaces;
using SecureVault.Models;
using SQLitePCL;

namespace SecureVault.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {

        // ۱. فیلد برای DbContext
        private readonly AppDbContext _context;

        // ۲. Constructor برای تزریق DbContext
        public PasswordRepository(AppDbContext context)
        {
            _context = context;
        }

        // ۳. پیاده‌سازی متدها:
        ////    - GetAllAsync
        //public Task<List<PasswordEntry>> GetAllAsync()
        //{
        //    return _context.PasswordEntries.ToListAsync();
        //}
        ////    - GetByIdAsync
        //public async Task<PasswordEntry?> GetByIdAsync(int id)
        //{
        //    return await _context.PasswordEntries.FindAsync(id);
        //}


        // NewMethod
        //GetAllByUserId
        public async Task<IEnumerable<PasswordEntry>> GetAllByUserIdAsync(int userId)
        {
            return await _context.PasswordEntries.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<PasswordEntry?> GetByIdAndUserIdAsync(int id, int userId)
        {
            return await _context.PasswordEntries.FirstOrDefaultAsync(i => i.Id == id && i.UserId == userId);
        }

        //    - AddAsync
        public async Task AddAsync(PasswordEntry passwordEntry)
        {
            await _context.PasswordEntries.AddAsync(passwordEntry);
        }
        //    - Remove
        public void Remove(PasswordEntry entry)
        {
            _context.PasswordEntries.Remove(entry);
        }
        //    - SaveChangesAsync
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        //    - SearchByUserIdAsync
        public async Task<IEnumerable<PasswordEntry>> SearchByUserIdAsync(string searchTerm, int userId)
        {
            return await _context.PasswordEntries.AsNoTracking()
                .Where(u => 
                    u.UserId == userId &&
                     (EF.Functions.Like(u.ServiceName, $"%{searchTerm}%") || EF.Functions.Like(u.URL,$"%{searchTerm}%")))
                .ToListAsync();
        }
    }
}