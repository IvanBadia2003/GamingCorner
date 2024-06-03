using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Consoles_Console_ConsoleId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Videogames_VideogameId",
                table: "OrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine");

            migrationBuilder.RenameTable(
                name: "OrderLine",
                newName: "OrderLines");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_VideogameId",
                table: "OrderLines",
                newName: "IX_OrderLines_VideogameId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLines",
                newName: "IX_OrderLines_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_Console_ConsoleId",
                table: "OrderLines",
                newName: "IX_OrderLines_Console_ConsoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines",
                column: "OrderLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Consoles_Console_ConsoleId",
                table: "OrderLines",
                column: "Console_ConsoleId",
                principalTable: "Consoles",
                principalColumn: "ConsoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Order_OrderId",
                table: "OrderLines",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Videogames_VideogameId",
                table: "OrderLines",
                column: "VideogameId",
                principalTable: "Videogames",
                principalColumn: "VideogameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Consoles_Console_ConsoleId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Order_OrderId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Videogames_VideogameId",
                table: "OrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines");

            migrationBuilder.RenameTable(
                name: "OrderLines",
                newName: "OrderLine");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_VideogameId",
                table: "OrderLine",
                newName: "IX_OrderLine_VideogameId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLine",
                newName: "IX_OrderLine_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLines_Console_ConsoleId",
                table: "OrderLine",
                newName: "IX_OrderLine_Console_ConsoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLine",
                table: "OrderLine",
                column: "OrderLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Consoles_Console_ConsoleId",
                table: "OrderLine",
                column: "Console_ConsoleId",
                principalTable: "Consoles",
                principalColumn: "ConsoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Videogames_VideogameId",
                table: "OrderLine",
                column: "VideogameId",
                principalTable: "Videogames",
                principalColumn: "VideogameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
