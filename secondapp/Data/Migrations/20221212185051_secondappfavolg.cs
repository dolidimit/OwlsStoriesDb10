using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondappfavolg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavBookLink",
                table: "FavouriteItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavBookPdf",
                table: "FavouriteItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavPages",
                table: "FavouriteItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BookPdf",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavBookLink",
                table: "FavouriteItems");

            migrationBuilder.DropColumn(
                name: "FavBookPdf",
                table: "FavouriteItems");

            migrationBuilder.DropColumn(
                name: "FavPages",
                table: "FavouriteItems");

            migrationBuilder.DropColumn(
                name: "BookPdf",
                table: "Events");
        }
    }
}
