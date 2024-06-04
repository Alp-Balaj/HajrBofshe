using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vectovia.Migrations
{
    /// <inheritdoc />
    public partial class AddinCompanieAndCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    MarkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriMarkes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.MarkaId);
                });

            migrationBuilder.CreateTable(
                name: "Qyteti",
                columns: table => new
                {
                    QytetiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qyteti", x => x.QytetiId);
                });

            migrationBuilder.CreateTable(
                name: "KompaniaRents",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kompania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QytetiId = table.Column<int>(type: "int", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigurimi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompaniaRents", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_KompaniaRents_Qyteti_QytetiId",
                        column: x => x.QytetiId,
                        principalTable: "Qyteti",
                        principalColumn: "QytetiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KompaniaTaxi",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kompania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryColour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryColour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumriKontaktues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigurimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QytetiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompaniaTaxi", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_KompaniaTaxi_Qyteti_QytetiId",
                        column: x => x.QytetiId,
                        principalTable: "Qyteti",
                        principalColumn: "QytetiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Tabelat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaID = table.Column<int>(type: "int", nullable: false),
                    CarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modeli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Karburanti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmisioni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VitiProdhimit = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Tabelat);
                    table.ForeignKey(
                        name: "FK_Car_KompaniaRents_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "KompaniaRents",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Marka_MarkaID",
                        column: x => x.MarkaID,
                        principalTable: "Marka",
                        principalColumn: "MarkaId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Car_CompanyID",
                table: "Car",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_MarkaID",
                table: "Car",
                column: "MarkaID");

            migrationBuilder.CreateIndex(
                name: "IX_KompaniaRents_QytetiId",
                table: "KompaniaRents",
                column: "QytetiId");

            migrationBuilder.CreateIndex(
                name: "IX_KompaniaTaxi_QytetiId",
                table: "KompaniaTaxi",
                column: "QytetiId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUpLocations_CompanyID",
                table: "PickUpLocations",
                column: "CompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "KompaniaTaxi");

            migrationBuilder.DropTable(
                name: "PickUpLocations");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropTable(
                name: "KompaniaRents");

            migrationBuilder.DropTable(
                name: "Qyteti");
        }
    }
}
