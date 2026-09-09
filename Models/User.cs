namespace SecureVault.Models;

public class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public required string Email { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; } 

    public bool IsEmailConfirmed { get; set; }
    public bool IsActive { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public ICollection<PasswordEntry> PasswordEntries { get; set; }=new List<PasswordEntry>();
}