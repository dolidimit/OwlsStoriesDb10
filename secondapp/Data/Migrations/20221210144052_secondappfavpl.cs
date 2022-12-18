using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondappfavpl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteBooks_Genres_FavGenreId",
                table: "FavouriteBooks");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteBooks_FavGenreId",
                table: "FavouriteBooks");

            migrationBuilder.DropColumn(
                name: "FavGenreId",
                table: "FavouriteBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavGenreId",
                table: "FavouriteBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteBooks_FavGenreId",
                table: "FavouriteBooks",
                column: "FavGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteBooks_Genres_FavGenreId",
                table: "FavouriteBooks",
                column: "FavGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
