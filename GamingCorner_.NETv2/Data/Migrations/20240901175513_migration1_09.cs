using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class migration1_09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    ConsoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.ConsoleId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterImg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Videogames",
                columns: table => new
                {
                    VideogameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pegi = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogames", x => x.VideogameId);
                    table.ForeignKey(
                        name: "FK_Videogames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Consoles",
                columns: new[] { "ConsoleId", "Available", "ImageURL", "Name", "Price", "Specifications", "Stock" },
                values: new object[,]
                {
                    { 1, true, "", "Play Station 4", 300m, "Ta bien", 16 },
                    { 2, true, "", "Xbox 360", 265m, "Ta bien pero no tanto", 5 }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "BackgroundImg", "CharacterImg", "Name" },
                values: new object[,]
                {
                    { 1, "", "", "RPG" },
                    { 2, "", "", "Shooter" },
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
                table: "Users",
                columns: new[] { "UserId", "Admin", "Email", "ImageURL", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, true, "diego@gmail.com", "", "Diego", "12345", "601112734" },
                    { 2, true, "ivan@gmail.com", "", "Ivan", "12345", "123456789" },
                    { 3, false, "adrian@gmail.com", "", "Adrian", "00000", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "VideogameId", "Available", "Description", "ImageURL", "Name", "Pegi", "Price", "Requisitos", "Stock", "UserId" },
                values: new object[,]
                {
                    { 1, true, "Altos carros voladores", "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp", "Rocket League", 12, 15m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 3, 1 },
                    { 2, true, "Gran Robo de Autos", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp", "GTA 5", 18, 13m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 7, 1 },
                    { 3, true, "Aventura épica en un mundo de fantasía", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp", "The Witcher 3", 18, 20m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 5, 2 },
                    { 4, true, "Juego de construcción y aventuras", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp", "Minecraft", 7, 25m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 10, 3 },
                    { 5, true, "Juego de supervivencia y construcción", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp", "Fortnite", 12, 0m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 8, 2 },
                    { 6, true, "Juego de disparos en equipo", "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp", "Overwatch", 12, 30m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 6, 1 },
                    { 7, true, "Simulación de fútbol", "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp", "FIFA 21", 3, 50m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 12, 2 },
                    { 8, true, "Aventura en un mundo futurista", "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp", "Cyberpunk 2077", 18, 60m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 4, 3 },
                    { 9, true, "Aventura en el Viejo Oeste", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp", "Red Dead Redemption 2", 18, 40m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 9, 3 },
                    { 10, true, "Aventura de vikingos", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp", "Assassin's Creed Valhalla", 18, 55m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 7, 1 },
                    { 11, true, "Juego de disparos en primera persona", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp", "Call of Duty: Modern Warfare", 18, 50m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 11, 1 },
                    { 12, true, "Aventura en un mundo postapocalíptico", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp", "Horizon Zero Dawn", 16, 35m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 5, 2 },
                    { 13, true, "Simulación de granja", "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp", "Stardew Valley", 7, 20m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 8, 2 },
                    { 14, true, "Juego de deducción social", "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp", "Among Us", 10, 5m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 15, 2 },
                    { 15, true, "Aventura en el mundo de Hyrule", "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png", "The Legend of Zelda: Breath of the Wild", 12, 60m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_UserId",
                table: "Videogames",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Videogames");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
