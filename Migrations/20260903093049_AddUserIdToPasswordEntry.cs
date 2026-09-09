using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureVault.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToPasswordEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PasswordEntries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PasswordEntries_UserId",
                table: "PasswordEntries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordEntries_Users_UserId",
                table: "PasswordEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordEntries_Users_UserId",
                table: "PasswordEntries");

            migrationBuilder.DropIndex(
                name: "IX_PasswordEntries_UserId",
                table: "PasswordEntries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PasswordEntries");
        }
    }
}
