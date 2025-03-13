using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S17L1.Migrations
{
    /// <inheritdoc />
    public partial class Tertial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCode",
                table: "User",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "IdCode");
        }
    }
}
