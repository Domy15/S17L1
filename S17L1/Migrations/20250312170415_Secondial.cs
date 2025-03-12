using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S17L1.Migrations
{
    /// <inheritdoc />
    public partial class Secondial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBook = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    BorrowEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => new { x.Id, x.IdBook });
                    table.ForeignKey(
                        name: "FK_Borrow_Books_IdBook",
                        column: x => x.IdBook,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrow_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_IdBook",
                table: "Borrow",
                column: "IdBook",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrow");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
