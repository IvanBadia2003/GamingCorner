using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class migration1_09_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Available", "Description", "ImageURL", "Name", "Price" },
                values: new object[] { 1, true, "COD BO4 nuevo en perfectas condiciones", "", "COD nuevo", 15m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Available", "Description", "ImageURL", "Name", "Price" },
                values: new object[] { 2, true, "Juego casi nuevo", "", "Uncharted", 10m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Available", "Description", "ImageURL", "Name", "Price" },
                values: new object[] { 3, true, "Practicamente nuevo", "", "Dark Souls", 7m });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "ProductId", "Type", "UserId" },
                values: new object[] { 1, 1, "Compra", 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "ProductId", "Type", "UserId" },
                values: new object[] { 2, 2, "Compra", 2 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "ProductId", "Type", "UserId" },
                values: new object[] { 3, 3, "Compra", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);
        }
    }
}
