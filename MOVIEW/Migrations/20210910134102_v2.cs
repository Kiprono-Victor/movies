using Microsoft.EntityFrameworkCore.Migrations;

namespace MOVIEW.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Db",
                table: "Order_Db");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "Order_Db",
                newName: "customer_Id");

            migrationBuilder.AlterColumn<string>(
                name: "customer_Id",
                table: "Order_Db",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "StrId",
                table: "Order_Db",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Db",
                table: "Order_Db",
                column: "StrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Db",
                table: "Order_Db");

            migrationBuilder.DropColumn(
                name: "StrId",
                table: "Order_Db");

            migrationBuilder.RenameColumn(
                name: "customer_Id",
                table: "Order_Db",
                newName: "Customer_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Customer_Id",
                table: "Order_Db",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Db",
                table: "Order_Db",
                column: "Customer_Id");
        }
    }
}
