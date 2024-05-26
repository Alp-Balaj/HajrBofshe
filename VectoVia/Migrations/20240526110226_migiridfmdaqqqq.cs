using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VectoVia.Migrations.KompaniaRentDb
{
    /// <inheritdoc />
    public partial class migiridfmdaqqqq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PickUpLocations_KompaniaRents_CompanyID",
                table: "PickUpLocations");

            migrationBuilder.DropColumn(
                name: "PickUpLocation",
                table: "KompaniaRents");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "PickUpLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PickUpLocations_KompaniaRents_CompanyID",
                table: "PickUpLocations",
                column: "CompanyID",
                principalTable: "KompaniaRents",
                principalColumn: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PickUpLocations_KompaniaRents_CompanyID",
                table: "PickUpLocations");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "PickUpLocations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickUpLocation",
                table: "KompaniaRents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PickUpLocations_KompaniaRents_CompanyID",
                table: "PickUpLocations",
                column: "CompanyID",
                principalTable: "KompaniaRents",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
