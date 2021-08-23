using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIEW.Migrations
{
    public partial class movijbhgasasdaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "strimageurl",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "strimageurl",
                table: "Movies");
        }
    }
}
