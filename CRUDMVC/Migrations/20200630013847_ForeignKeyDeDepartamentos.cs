using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDMVC.Migrations
{
    public partial class ForeignKeyDeDepartamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamentos_DepartamentosId",
                table: "Vendedor");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentosId",
                table: "Vendedor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamentos_DepartamentosId",
                table: "Vendedor",
                column: "DepartamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamentos_DepartamentosId",
                table: "Vendedor");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentosId",
                table: "Vendedor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamentos_DepartamentosId",
                table: "Vendedor",
                column: "DepartamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
