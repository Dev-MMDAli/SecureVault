using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureVault.Migrations
{
    /// <inheritdoc />
    public partial class RenameSiteFieldsToServiceFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SiteURL",
                table: "PasswordEntries",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "SiteName",
                table: "PasswordEntries",
                newName: "ServiceName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URL",
                table: "PasswordEntries",
                newName: "SiteURL");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "PasswordEntries",
                newName: "SiteName");
        }
    }
}
