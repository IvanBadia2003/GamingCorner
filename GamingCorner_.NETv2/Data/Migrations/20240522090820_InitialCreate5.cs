using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Platform",
                table: "Platform");

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Videogames");

            migrationBuilder.RenameTable(
                name: "Platform",
                newName: "Platforms");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "Videogames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Console_ConsoleId",
                table: "OrderLine",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platforms",
                table: "Platforms",
                column: "PlatformId");

            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    ConsoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.ConsoleId);
                    table.ForeignKey(
                        name: "FK_Consoles_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "BackgroundImg", "CharacterImg", "Name" },
                values: new object[,]
                {
                    { 3, "", "", "Estrategia" },
                    { 4, "", "", "Accion" },
                    { 5, "", "", "Deportes" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "Name" },
                values: new object[,]
                {
                    { 1, "Steam" },
                    { 2, "Play Station" },
                    { 3, "Xbox" },
                    { 4, "Switch" }
                });

            migrationBuilder.InsertData(
                table: "VideogameGenders",
                columns: new[] { "GenderId", "VideogameId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Consoles",
                columns: new[] { "ConsoleId", "Available", "ImageURL", "Name", "PlatformId", "Price", "Specifications", "Stock" },
                values: new object[,]
                {
                    { 1, true, "", "Play Station 4", 2, 300m, "Ta bien", 16 },
                    { 2, true, "", "Xbox 360", 3, 265m, "Ta bien pero no tanto", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 1,
                columns: new[] { "Category", "ImageURL", "PlatformId" },
                values: new object[] { "Deportes", "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp", 1 });

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 2,
                columns: new[] { "Category", "ImageURL", "PlatformId" },
                values: new object[] { "Acción", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp", 2 });

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "VideogameId", "Available", "Category", "Description", "ImageURL", "Name", "Pegi", "PlatformId", "Price", "Stock" },
                values: new object[,]
                {
                    { 3, true, "RPG", "Aventura épica en un mundo de fantasía", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp", "The Witcher 3", 18, 1, 20m, 5 },
                    { 4, true, "Aventura", "Juego de construcción y aventuras", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp", "Minecraft", 7, 3, 25m, 10 },
                    { 5, true, "Acción", "Juego de supervivencia y construcción", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp", "Fortnite", 12, 1, 0m, 8 },
                    { 6, true, "Acción", "Juego de disparos en equipo", "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp", "Overwatch", 12, 2, 30m, 6 },
                    { 7, true, "Deportes", "Simulación de fútbol", "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp", "FIFA 21", 3, 3, 50m, 12 },
                    { 8, true, "RPG", "Aventura en un mundo futurista", "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp", "Cyberpunk 2077", 18, 1, 60m, 4 },
                    { 9, true, "Acción", "Aventura en el Viejo Oeste", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp", "Red Dead Redemption 2", 18, 2, 40m, 9 },
                    { 10, true, "Aventura", "Aventura de vikingos", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp", "Assassin's Creed Valhalla", 18, 3, 55m, 7 },
                    { 11, true, "Acción", "Juego de disparos en primera persona", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp", "Call of Duty: Modern Warfare", 18, 1, 50m, 11 },
                    { 12, true, "Aventura", "Aventura en un mundo postapocalíptico", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp", "Horizon Zero Dawn", 16, 1, 35m, 5 },
                    { 13, true, "Simulación", "Simulación de granja", "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp", "Stardew Valley", 7, 4, 20m, 8 },
                    { 14, true, "Multijugador", "Juego de deducción social", "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp", "Among Us", 10, 1, 5m, 15 },
                    { 15, true, "Aventura", "Aventura en el mundo de Hyrule", "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png", "The Legend of Zelda: Breath of the Wild", 12, 4, 60m, 6 }
                });

            migrationBuilder.InsertData(
                table: "VideogameGenders",
                columns: new[] { "GenderId", "VideogameId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 1, 6 },
                    { 2, 7 },
                    { 3, 8 },
                    { 4, 9 },
                    { 5, 10 },
                    { 1, 11 },
                    { 2, 12 },
                    { 3, 13 },
                    { 4, 14 },
                    { 5, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_PlatformId",
                table: "Videogames",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_Console_ConsoleId",
                table: "OrderLine",
                column: "Console_ConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Consoles_PlatformId",
                table: "Consoles",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Consoles_Console_ConsoleId",
                table: "OrderLine",
                column: "Console_ConsoleId",
                principalTable: "Consoles",
                principalColumn: "ConsoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videogames_Platforms_PlatformId",
                table: "Videogames",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Consoles_Console_ConsoleId",
                table: "OrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_Videogames_Platforms_PlatformId",
                table: "Videogames");

            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropIndex(
                name: "IX_Videogames_PlatformId",
                table: "Videogames");

            migrationBuilder.DropIndex(
                name: "IX_OrderLine_Console_ConsoleId",
                table: "OrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Platforms",
                table: "Platforms");

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Videogames");

            migrationBuilder.DropColumn(
                name: "Console_ConsoleId",
                table: "OrderLine");

            migrationBuilder.RenameTable(
                name: "Platforms",
                newName: "Platform");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Videogames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platform",
                table: "Platform",
                column: "PlatformId");

            migrationBuilder.InsertData(
                table: "VideogameGenders",
                columns: new[] { "GenderId", "VideogameId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 1,
                columns: new[] { "Category", "ImageURL", "Platform" },
                values: new object[] { "", "", "Steam" });

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 2,
                columns: new[] { "Category", "ImageURL", "Platform" },
                values: new object[] { "", "", "Play Station" });
        }
    }
}
