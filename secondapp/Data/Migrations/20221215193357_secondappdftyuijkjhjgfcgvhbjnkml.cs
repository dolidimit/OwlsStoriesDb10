using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondappdftyuijkjhjgfcgvhbjnkml : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinshedBooks_AspNetUsers_UserId",
                table: "FinshedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_FinshedBooks_Stories_StoryId",
                table: "FinshedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinshedBooks",
                table: "FinshedBooks");

            migrationBuilder.RenameTable(
                name: "FinshedBooks",
                newName: "FinshedBooksUs");

            migrationBuilder.RenameIndex(
                name: "IX_FinshedBooks_StoryId",
                table: "FinshedBooksUs",
                newName: "IX_FinshedBooksUs_StoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinshedBooksUs",
                table: "FinshedBooksUs",
                columns: new[] { "UserId", "StoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FinshedBooksUs_AspNetUsers_UserId",
                table: "FinshedBooksUs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinshedBooksUs_Stories_StoryId",
                table: "FinshedBooksUs",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinshedBooksUs_AspNetUsers_UserId",
                table: "FinshedBooksUs");

            migrationBuilder.DropForeignKey(
                name: "FK_FinshedBooksUs_Stories_StoryId",
                table: "FinshedBooksUs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinshedBooksUs",
                table: "FinshedBooksUs");

            migrationBuilder.RenameTable(
                name: "FinshedBooksUs",
                newName: "FinshedBooks");

            migrationBuilder.RenameIndex(
                name: "IX_FinshedBooksUs_StoryId",
                table: "FinshedBooks",
                newName: "IX_FinshedBooks_StoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinshedBooks",
                table: "FinshedBooks",
                columns: new[] { "UserId", "StoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FinshedBooks_AspNetUsers_UserId",
                table: "FinshedBooks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinshedBooks_Stories_StoryId",
                table: "FinshedBooks",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
