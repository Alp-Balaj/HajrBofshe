using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VectoVia.Migrations.KompaniaRentDb
{
    /// <inheritdoc />
    public partial class migrimiL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PickUpLocations",
                columns: table => new
                {
                    PickUpLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUpLocations", x => x.PickUpLocationID);
                    table.ForeignKey(
                        name: "FK_PickUpLocations_KompaniaRents_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "KompaniaRents",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PickUpLocations_CompanyID",
                table: "PickUpLocations",
                column: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PickUpLocations");
        }
    }
}
