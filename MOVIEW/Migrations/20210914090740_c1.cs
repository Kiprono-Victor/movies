using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIEW.Migrations
{
    public partial class c1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Db",
                table: "Order_Db");

            migrationBuilder.DropColumn(
                name: "StrId",
                table: "Order_Db");

            migrationBuilder.DropColumn(
                name: "customer_Id",
                table: "Order_Db");

            migrationBuilder.RenameColumn(
                name: "Movie_Id",
                table: "Order_Db",
                newName: "strMovieName");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Order_Db",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Db",
                table: "Order_Db",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Db",
                table: "Order_Db");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Order_Db");

            migrationBuilder.RenameColumn(
                name: "strMovieName",
                table: "Order_Db",
                newName: "Movie_Id");

            migrationBuilder.AddColumn<string>(
                name: "StrId",
                table: "Order_Db",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "customer_Id",
                table: "Order_Db",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Db",
                table: "Order_Db",
                column: "StrId");
        }
    }
}
