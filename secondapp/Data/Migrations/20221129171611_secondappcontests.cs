using Microsoft.EntityFrameworkCore.Migrations;

namespace secondapp.Data.Migrations
{
    public partial class secondappcontests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContestId",
                table: "Stories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(105)", maxLength: 105, nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(105)", maxLength: 105, nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(105)", maxLength: 105, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(195)", maxLength: 195, nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContestAuthor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JuryTeam = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    PriceTitle = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    PriceImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceLinkProd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceDescription = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Open = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_ContestId",
                table: "Stories",
                column: "ContestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Contests_ContestId",
                table: "Stories",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Contests_ContestId",
                table: "Stories");

            migrationBuilder.DropTable(
                name: "Contests");

            migrationBuilder.DropIndex(
                name: "IX_Stories_ContestId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "ContestId",
                table: "Stories");
        }
    }
}
