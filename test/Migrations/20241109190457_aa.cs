using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_mainitem_idmain",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "idmain",
                table: "Item",
                newName: "mainitemId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_idmain",
                table: "Item",
                newName: "IX_Item_mainitemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_mainitem_mainitemId",
                table: "Item",
                column: "mainitemId",
                principalTable: "mainitem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_mainitem_mainitemId",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "mainitemId",
                table: "Item",
                newName: "idmain");

            migrationBuilder.RenameIndex(
                name: "IX_Item_mainitemId",
                table: "Item",
                newName: "IX_Item_idmain");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_mainitem_idmain",
                table: "Item",
                column: "idmain",
                principalTable: "mainitem",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
