using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogameGender_Genders_GenderId",
                table: "VideogameGender");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogameGender_Videogames_VideogameId",
                table: "VideogameGender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideogameGender",
                table: "VideogameGender");

            migrationBuilder.RenameTable(
                name: "VideogameGender",
                newName: "VideogameGenders");

            migrationBuilder.RenameIndex(
                name: "IX_VideogameGender_GenderId",
                table: "VideogameGenders",
                newName: "IX_VideogameGenders_GenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideogameGenders",
                table: "VideogameGenders",
                columns: new[] { "VideogameId", "GenderId" });

            migrationBuilder.InsertData(
                table: "VideogameGenders",
                columns: new[] { "GenderId", "VideogameId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "VideogameGenders",
                columns: new[] { "GenderId", "VideogameId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "VideogameGenders",
                columns: new[] { "GenderId", "VideogameId" },
                values: new object[] { 2, 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameGenders_Genders_GenderId",
                table: "VideogameGenders",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameGenders_Videogames_VideogameId",
                table: "VideogameGenders",
                column: "VideogameId",
                principalTable: "Videogames",
                principalColumn: "VideogameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideogameGenders_Genders_GenderId",
                table: "VideogameGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_VideogameGenders_Videogames_VideogameId",
                table: "VideogameGenders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideogameGenders",
                table: "VideogameGenders");

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "VideogameGenders",
                keyColumns: new[] { "GenderId", "VideogameId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.RenameTable(
                name: "VideogameGenders",
                newName: "VideogameGender");

            migrationBuilder.RenameIndex(
                name: "IX_VideogameGenders_GenderId",
                table: "VideogameGender",
                newName: "IX_VideogameGender_GenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideogameGender",
                table: "VideogameGender",
                columns: new[] { "VideogameId", "GenderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameGender_Genders_GenderId",
                table: "VideogameGender",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideogameGender_Videogames_VideogameId",
                table: "VideogameGender",
                column: "VideogameId",
                principalTable: "Videogames",
                principalColumn: "VideogameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
