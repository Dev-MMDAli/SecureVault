namespace SecureVault.DTOs
{
    public class CreatePasswordDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string HashPassword { get; set; }
        public string? MailAddress { get; set; }
        public string? Username { get; set; }

        public required string ServiceName { get; set; }
        public string? URL { get; set; }

    }
}
   