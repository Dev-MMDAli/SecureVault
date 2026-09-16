using SecureVault.DTOs;
using SecureVault.Models;

namespace SecureVault.Interfaces
{
    public interface IPasswordService
    {

        // ۱. ایجاد رکورد جدید
        //    ورودی: CreatePasswordDto
        //    خروجی: PasswordEntry
        Task<PasswordEntry> AddAsync(CreatePasswordDto dto,int userId);
        // ۲. گرفتن همه رکوردها
        //    ورودی: -
        //    خروجی: List<PasswordEntry>
        Task<IEnumerable<PasswordEntry>> GetAllAsync(int userId);
        // ۳. گرفتن یک رکورد با ID
        //    ورودی: int id
        //    خروجی: PasswordEntry?
        Task<PasswordEntry?> GetByIdAsync(int id,int userId);
        // ۴. ویرایش جزئی رکورد
        //    ورودی: int id + PatchPasswordDto
        //    خروجی: PasswordEntry?
        Task<PasswordEntry?> PatchAsync(int id,int userId,PatchPasswordDto dto);
        // ۵. حذف رکورد
        //    ورودی: int id
        //    خروجی: -
        Task<bool> DeleteAsync(int id,int userId);

        // 6 search serviceName or url
        // input : string search, int userId
        // output : PasswordEntry?
        Task<IEnumerable<PasswordEntry>> SearchAsync(string search,int userId);
    }
}
