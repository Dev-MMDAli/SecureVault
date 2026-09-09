
namespace SecureVault.Models
{
    public class PasswordEntry
    {
        public int Id{set;get;}
        public int UserId { get; set; }
        public string? FirstName{set;get;}
        public string? LastName{set;get;}
        public string? MailAddress{set;get;}
        public string? Username{set;get;}
        public string HashPassword{set;get;}
        public string? ServiceName { set;get;}
        public string? URL{set;get;}
        public DateTime CreateDate{set;get;}
        public DateTime? EditDate { set; get; }
        public User User { get; set; }
    }
}
