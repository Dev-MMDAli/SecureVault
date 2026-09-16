using System.Collections;
using SecureVault.DTOs;
using SecureVault.Interfaces;
using SecureVault.Models;

namespace SecureVault.Services
{
    public class PasswordService:IPasswordService
    {

        // ۱. فیلدها برای Repository و EncryptionService
        readonly private IPasswordRepository _repository;
        readonly private EncryptionService _encrypt;
        // ۲. Constructor برای تزریق هر دو
        public PasswordService(IPasswordRepository repository,EncryptionService encrypt)
        {
            _repository=repository;
            _encrypt=encrypt;
        }
        // ۳. پیاده‌سازی متدها:
        //    - AddAsync (رمزنگاری + ذخیره)
        public async Task<PasswordEntry> AddAsync(CreatePasswordDto dto, int userId)
        {

            var encryptedPassword = _encrypt.Encrypt(dto.HashPassword);

            var entry = new PasswordEntry
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Username = dto.Username,
                MailAddress = dto.MailAddress,
                ServiceName = dto.ServiceName,
                URL = dto.URL,
                CreateDate = DateTime.UtcNow,
                EditDate = null,
                HashPassword = encryptedPassword,
                UserId = userId
            };

            await _repository.AddAsync(entry);
            await _repository.SaveChangesAsync();
            return entry;
        }
        
        //    - GetAllAsync (رمزگشایی همه)
        public async Task<IEnumerable<PasswordEntry>> GetAllAsync(int userId)
        {
            var entries= await _repository.GetAllByUserIdAsync(userId);

            foreach (var entry in entries)
            {
                entry.HashPassword = _encrypt.Decrypt(entry.HashPassword);
            }

            return entries;
        }

        //    - GetByIdAsync (رمزگشایی یک رکورد)
        public async Task<PasswordEntry?> GetByIdAsync(int id,int userId)
        {
            var entry= await _repository.GetByIdAndUserIdAsync(id,userId);
            if (entry==null)
            {
                return null;

            }
            entry.HashPassword= _encrypt.Decrypt(entry.HashPassword);
            return entry;
        } 

        //    - PatchAsync (رمزنگاری + آپدیت)
        public async Task<PasswordEntry?> PatchAsync(int id,int userId,PatchPasswordDto dto)
        {
            var entry =await _repository.GetByIdAndUserIdAsync(id,userId);
            if (entry == null)
            {
                return null;
            }
            if (dto.FirstName != null)
            {
                entry.FirstName=dto.FirstName;
            }

            if (dto.LastName!=null)
            {
                entry.LastName=dto.LastName;
            }

            if (dto.Username!=null)
            {
                entry.Username=dto.Username;
            }

            if (dto.MailAddress!=null)
            {
                entry.MailAddress=dto.MailAddress;
            }

            if (dto.HashPassword!=null)
            {
                entry.HashPassword =_encrypt.Encrypt(dto.HashPassword);
            }

            if (dto.ServiceName!=null)
            {
                entry.ServiceName=dto.ServiceName;
            }

            if (dto.URL!=null)
            {
                entry.URL=dto.URL;
            }

            entry.EditDate = DateTime.UtcNow;
            await _repository.SaveChangesAsync();

            return entry;

        }
        //    - DeleteAsync (پیدا کردن + حذف) 

        public async Task<bool> DeleteAsync(int id,int userId)
        {
            var entry= await _repository.GetByIdAndUserIdAsync(id,userId);
            if (entry== null)
            {
                return false;
            }
            else
            {
               _repository.Remove(entry);
               await _repository.SaveChangesAsync();
               return true;
            }
        }

        public async Task<IEnumerable<PasswordEntry>> SearchAsync(string searchTerm, int userId)
        {

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Enumerable.Empty<PasswordEntry>();
            }
            var result= await _repository.SearchByUserIdAsync(searchTerm, userId);

            foreach (var password in result)
                {
                    password.HashPassword = _encrypt.Decrypt(password.HashPassword);
                }
            

            return result;
        }
    }
}
