using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondappfavpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cart_CartId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FavouriteBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavTitle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FavGenreId = table.Column<int>(type: "int", nullable: false),
                    FavTopic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FavUserAuthor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FavCon = table.Column<string>(type: "nvarchar(max)", maxLength: 8097, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteBook_Genres_FavGenreId",
                        column: x => x.FavGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PUserFullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PostTopic = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CurrentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumOrder = table.Column<int>(type: "int", nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteBook_FavGenreId",
                table: "FavouriteBook",
                column: "FavGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FavouriteBook");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cart_CartId",
                table: "Products",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
