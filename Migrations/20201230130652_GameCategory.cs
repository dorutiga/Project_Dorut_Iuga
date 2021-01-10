using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Dorut_Iuga.Migrations
{
    public partial class GameCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeveloperID",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GameCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GameCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCategory_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_DeveloperID",
                table: "Game",
                column: "DeveloperID");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategory_CategoryID",
                table: "GameCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategory_GameID",
                table: "GameCategory",
                column: "GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Developer_DeveloperID",
                table: "Game",
                column: "DeveloperID",
                principalTable: "Developer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Developer_DeveloperID",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "GameCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Game_DeveloperID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "DeveloperID",
                table: "Game");
        }
    }
}
