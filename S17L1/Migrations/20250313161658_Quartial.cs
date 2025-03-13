using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S17L1.Migrations
{
    /// <inheritdoc />
    public partial class Quartial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Books_IdBook",
                table: "Borrow");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_User_Id",
                table: "Borrow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Borrow",
                table: "Borrow");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Borrow",
                newName: "Borrows");

            migrationBuilder.RenameIndex(
                name: "IX_Borrow_IdBook",
                table: "Borrows",
                newName: "IX_Borrows_IdBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Borrows",
                table: "Borrows",
                columns: new[] { "Id", "IdBook" });

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Books_IdBook",
                table: "Borrows",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_Id",
                table: "Borrows",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Books_IdBook",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Users_Id",
                table: "Borrows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Borrows",
                table: "Borrows");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Borrows",
                newName: "Borrow");

            migrationBuilder.RenameIndex(
                name: "IX_Borrows_IdBook",
                table: "Borrow",
                newName: "IX_Borrow_IdBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Borrow",
                table: "Borrow",
                columns: new[] { "Id", "IdBook" });

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Books_IdBook",
                table: "Borrow",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_User_Id",
                table: "Borrow",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
