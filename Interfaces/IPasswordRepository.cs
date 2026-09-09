using SecureVault.Models;

namespace SecureVault.Interfaces
{
    public interface IPasswordRepository
    {
     
        // نمایش تمامی حساب ها
        //Task<List<PasswordEntry>> GetAllAsync();
        Task<IEnumerable<PasswordEntry>> GetAllByUserIdAsync(int userId); 
        // نمایش حساب مشخص با ایدی
        // Task<PasswordEntry?> GetByIdAsync(int id);
        Task<PasswordEntry?> GetByIdAndUserIdAsync(int id, int userId);
        //افزودن حساب جدید
        Task AddAsync(PasswordEntry entry);

        // حذف حساب مشخص
        void Remove(PasswordEntry entry);

        // دخیره تغییرات 
        Task SaveChangesAsync();
    }
}
