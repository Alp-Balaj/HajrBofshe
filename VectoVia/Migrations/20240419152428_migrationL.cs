using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VectoVia.Migrations
{
    /// <inheritdoc />
    public partial class migrationL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxiCars",
                columns: table => new
                {
                    Targat = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaxiID = table.Column<int>(type: "int", nullable: false),
                    nrPassenger = table.Column<int>(type: "int", nullable: false),
                    hapesiraNeBagazh = table.Column<int>(type: "int", nullable: false),
                    llojiVetures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    llojiKarburantit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iDisponueshem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiCars", x => x.Targat);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxiCars");
        }
    }
}
