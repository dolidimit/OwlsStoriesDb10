using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondappfavbopostsggh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Stories");
        }
    }
}
