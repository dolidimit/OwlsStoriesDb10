using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondappfavitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteBooks");

            migrationBuilder.CreateTable(
                name: "FavouriteItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavTitle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FavTopic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FavUserAuthor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FavImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavCon = table.Column<string>(type: "nvarchar(max)", maxLength: 8097, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteItems");

            migrationBuilder.CreateTable(
                name: "FavouriteBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavCon = table.Column<string>(type: "nvarchar(max)", maxLength: 8097, nullable: false),
                    FavTitle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FavTopic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FavUserAuthor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteBooks", x => x.Id);
                });
        }
    }
}
