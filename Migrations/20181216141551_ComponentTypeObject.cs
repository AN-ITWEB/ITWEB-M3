using Microsoft.EntityFrameworkCore.Migrations;

namespace ITWEB_M3.Migrations
{
    public partial class ComponentTypeObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_ComponentTypes_ComponentTypeId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentTypes_Categories_CategoryId",
                table: "ComponentTypes");

            migrationBuilder.DropIndex(
                name: "IX_ComponentTypes_CategoryId",
                table: "ComponentTypes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ComponentTypes");

            migrationBuilder.AlterColumn<long>(
                name: "ComponentTypeId",
                table: "Components",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Components_ComponentTypes_ComponentTypeId",
                table: "Components",
                column: "ComponentTypeId",
                principalTable: "ComponentTypes",
                principalColumn: "ComponentTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_ComponentTypes_ComponentTypeId",
                table: "Components");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ComponentTypes",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ComponentTypeId",
                table: "Components",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentTypes_CategoryId",
                table: "ComponentTypes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_ComponentTypes_ComponentTypeId",
                table: "Components",
                column: "ComponentTypeId",
                principalTable: "ComponentTypes",
                principalColumn: "ComponentTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentTypes_Categories_CategoryId",
                table: "ComponentTypes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
