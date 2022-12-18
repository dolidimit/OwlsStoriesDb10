using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondappdapsotsfavo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteBook_Genres_FavGenreId",
                table: "FavouriteBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteBook",
                table: "FavouriteBook");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "FavouriteBook",
                newName: "FavouriteBooks");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteBook_FavGenreId",
                table: "FavouriteBooks",
                newName: "IX_FavouriteBooks_FavGenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteBooks",
                table: "FavouriteBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteBooks_Genres_FavGenreId",
                table: "FavouriteBooks",
                column: "FavGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteBooks_Genres_FavGenreId",
                table: "FavouriteBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteBooks",
                table: "FavouriteBooks");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "FavouriteBooks",
                newName: "FavouriteBook");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteBooks_FavGenreId",
                table: "FavouriteBook",
                newName: "IX_FavouriteBook_FavGenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteBook",
                table: "FavouriteBook",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteBook_Genres_FavGenreId",
                table: "FavouriteBook",
                column: "FavGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
