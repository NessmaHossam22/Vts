using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "customer_name",
                table: "invoice");

            migrationBuilder.AddColumn<int>(
                name: "itemId",
                table: "invoiceDetlies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "diCount",
                table: "invoice",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_invoiceDetlies_itemId",
                table: "invoiceDetlies",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_UserId",
                table: "invoice",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_Users_UserId",
                table: "invoice",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invoiceDetlies_Item_itemId",
                table: "invoiceDetlies",
                column: "itemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoice_Users_UserId",
                table: "invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_invoiceDetlies_Item_itemId",
                table: "invoiceDetlies");

            migrationBuilder.DropIndex(
                name: "IX_invoiceDetlies_itemId",
                table: "invoiceDetlies");

            migrationBuilder.DropIndex(
                name: "IX_invoice_UserId",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "itemId",
                table: "invoiceDetlies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "diCount",
                table: "invoice");

            migrationBuilder.AddColumn<string>(
                name: "customer_name",
                table: "invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
