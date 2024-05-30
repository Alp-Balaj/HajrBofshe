using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vectovia.Migrations.KompaniaRentDb
{
    /// <inheritdoc />
    public partial class migrationX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KompaniaRents",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kompania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qyteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigurimi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompaniaRents", x => x.CompanyID);
                });

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
                    CompanyID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.DropTable(
                name: "KompaniaRents");
        }
    }
}
