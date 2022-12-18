using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondeventappeve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookResume",
                table: "Events",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookTitle",
                table: "Events",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GuestAuthorImage",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookResume",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "BookTitle",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "GuestAuthorImage",
                table: "Events");
        }
    }
}
