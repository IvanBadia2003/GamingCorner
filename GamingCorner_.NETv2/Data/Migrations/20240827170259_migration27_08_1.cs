using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class migration27_08_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogames", x => x.VideogameId);
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
                columns: new[] { "VideogameId", "Available", "Description", "ImageURL", "Name", "Pegi", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, true, "Altos carros voladores", "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp", "Rocket League", 12, 15m, 3 },
                    { 2, true, "Gran Robo de Autos", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp", "GTA 5", 18, 13m, 7 },
                    { 3, true, "Aventura épica en un mundo de fantasía", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp", "The Witcher 3", 18, 20m, 5 },
                    { 4, true, "Juego de construcción y aventuras", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp", "Minecraft", 7, 25m, 10 },
                    { 5, true, "Juego de supervivencia y construcción", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp", "Fortnite", 12, 0m, 8 },
                    { 6, true, "Juego de disparos en equipo", "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp", "Overwatch", 12, 30m, 6 },
                    { 7, true, "Simulación de fútbol", "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp", "FIFA 21", 3, 50m, 12 },
                    { 8, true, "Aventura en un mundo futurista", "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp", "Cyberpunk 2077", 18, 60m, 4 },
                    { 9, true, "Aventura en el Viejo Oeste", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp", "Red Dead Redemption 2", 18, 40m, 9 },
                    { 10, true, "Aventura de vikingos", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp", "Assassin's Creed Valhalla", 18, 55m, 7 },
                    { 11, true, "Juego de disparos en primera persona", "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp", "Call of Duty: Modern Warfare", 18, 50m, 11 },
                    { 12, true, "Aventura en un mundo postapocalíptico", "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp", "Horizon Zero Dawn", 16, 35m, 5 },
                    { 13, true, "Simulación de granja", "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp", "Stardew Valley", 7, 20m, 8 },
                    { 14, true, "Juego de deducción social", "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp", "Among Us", 10, 5m, 15 },
                    { 15, true, "Aventura en el mundo de Hyrule", "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png", "The Legend of Zelda: Breath of the Wild", 12, 60m, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Videogames");
        }
    }
}
