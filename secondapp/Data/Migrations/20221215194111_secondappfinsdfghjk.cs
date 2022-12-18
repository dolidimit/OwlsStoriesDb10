using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondappfinsdfghjk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinishedStories",
                columns: table => new
                {
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    StoryTitle = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    StoryTopic = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    StoryAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StoryUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoryText = table.Column<string>(type: "nvarchar(max)", maxLength: 8080, nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinishedStories");
        }
    }
}
