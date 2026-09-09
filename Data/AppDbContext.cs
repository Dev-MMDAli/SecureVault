using Microsoft.EntityFrameworkCore;
using SecureVault.Models;

namespace SecureVault.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        // برای این کار از DbSet استفاده می‌کنیم.
        // ساختار: public DbSet<نام_کلاس_مدل> نام_جدول { get; set; }
       public DbSet<PasswordEntry> PasswordEntries { get; set; }
       public DbSet<User> Users { get; set; }


    }
}
