using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIEW.Migrations
{
    public partial class movijbhg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    strId = table.Column<string>(maxLength: 50, nullable: false),
                    strMovieName = table.Column<string>(nullable: true),
                    strPrice = table.Column<string>(nullable: true),
                    strDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.strId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
