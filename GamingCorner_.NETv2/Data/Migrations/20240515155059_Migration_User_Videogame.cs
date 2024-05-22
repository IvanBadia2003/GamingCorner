using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class Migration_User_Videogame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogameGenre_Videogame_VideogameId",
                table: "VideogameGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videogame",
                table: "Videogame");

            migrationBuilder.RenameTable(
                name: "Videogame",
                newName: "Videogames");

            migrationBuilder.RenameColumn(
                name: "URL",
                table: "Videogames",
                newName: "ImageURL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videogames",
                table: "Videogames",
                column: "VideogameId");

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "VideogameId", "Available", "Category", "Description", "ImageURL", "Name", "Pegi", "Platform", "Price", "Stock" },
                values: new object[] { 1, true, "", "Altos carros voladores", "", "Rocket League", 12, "Steam", 15m, 3 });

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "VideogameId", "Available", "Category", "Description", "ImageURL", "Name", "Pegi", "Platform", "Price", "Stock" },
                values: new object[] { 2, true, "", "Gran Robo de Autos", "", "GTA 5", 18, "Play Station", 13m, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_VideogameId",
                table: "OrderLine",
                column: "VideogameId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Videogames_VideogameId",
                table: "OrderLine",
                column: "VideogameId",
                principalTable: "Videogames",
                principalColumn: "VideogameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameGenre_Videogames_VideogameId",
                table: "VideogameGenre",
                column: "VideogameId",
                principalTable: "Videogames",
                principalColumn: "VideogameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Videogames_VideogameId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogameGenre_Videogames_VideogameId",
                table: "VideogameGenre");

            migrationBuilder.DropIndex(
                name: "IX_OrderLine_VideogameId",
                table: "OrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videogames",
                table: "Videogames");

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Videogames",
                newName: "Videogame");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Videogame",
                newName: "URL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videogame",
                table: "Videogame",
                column: "VideogameId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameGenre_Videogame_VideogameId",
                table: "VideogameGenre",
                column: "VideogameId",
                principalTable: "Videogame",
                principalColumn: "VideogameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
