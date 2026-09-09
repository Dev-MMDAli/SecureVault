namespace SecureVault.DTOs
{
    public class PatchPasswordDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? HashPassword { get; set; }
        public string? MailAddress { get; set; }
        public string? Username { get; set; }
        public string? ServiceName { get; set; }

        public string? URL { get; set; }
    }
}
