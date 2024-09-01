using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class migration1_09_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ConsoleId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideogameId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Address",
                value: "C/ La Lectura");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Address",
                value: "Avda. San Juan de la Peña");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Address",
                value: "El Actur");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ConsoleId",
                table: "Transactions",
                column: "ConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_VideogameId",
                table: "Transactions",
                column: "VideogameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Consoles_ConsoleId",
                table: "Transactions",
                column: "ConsoleId",
                principalTable: "Consoles",
                principalColumn: "ConsoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Videogames_VideogameId",
                table: "Transactions",
                column: "VideogameId",
                principalTable: "Videogames",
                principalColumn: "VideogameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Consoles_ConsoleId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Videogames_VideogameId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ConsoleId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_VideogameId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConsoleId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "VideogameId",
                table: "Transactions");
        }
    }
}
