using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VectoVia.Migrations.CarsDb
{
    /// <inheritdoc />
    public partial class migrimiVetura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDBO_KompaniaRent_CompanyID",
                table: "CarDBO");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDBO_Markat_MarkaID",
                table: "CarDBO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDBO",
                table: "CarDBO");

            migrationBuilder.RenameTable(
                name: "CarDBO",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_CarDBO_MarkaID",
                table: "Cars",
                newName: "IX_Cars_MarkaID");

            migrationBuilder.RenameIndex(
                name: "IX_CarDBO_CompanyID",
                table: "Cars",
                newName: "IX_Cars_CompanyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Tabelat");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_KompaniaRent_CompanyID",
                table: "Cars",
                column: "CompanyID",
                principalTable: "KompaniaRent",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Markat_MarkaID",
                table: "Cars",
                column: "MarkaID",
                principalTable: "Markat",
                principalColumn: "MarkaId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_KompaniaRent_CompanyID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Markat_MarkaID",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "CarDBO");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_MarkaID",
                table: "CarDBO",
                newName: "IX_CarDBO_MarkaID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CompanyID",
                table: "CarDBO",
                newName: "IX_CarDBO_CompanyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDBO",
                table: "CarDBO",
                column: "Tabelat");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDBO_KompaniaRent_CompanyID",
                table: "CarDBO",
                column: "CompanyID",
                principalTable: "KompaniaRent",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDBO_Markat_MarkaID",
                table: "CarDBO",
                column: "MarkaID",
                principalTable: "Markat",
                principalColumn: "MarkaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
