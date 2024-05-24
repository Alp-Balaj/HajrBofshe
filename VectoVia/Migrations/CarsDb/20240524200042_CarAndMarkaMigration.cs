using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vectovia.Migrations.CarsDb
{
    /// <inheritdoc />
    public partial class CarAndMarkaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markat",
                columns: table => new
                {
                    MarkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriMarkes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markat", x => x.MarkaId);
                });

            migrationBuilder.CreateTable(
                name: "CarDBO",
                columns: table => new
                {
                    Tabelat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaID = table.Column<int>(type: "int", nullable: false),
                    Modeli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Karburanti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmisioni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VitiProdhimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDBO", x => x.Tabelat);
                    table.ForeignKey(
                        name: "FK_CarDBO_Markat_MarkaID",
                        column: x => x.MarkaID,
                        principalTable: "Markat",
                        principalColumn: "MarkaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDBO_MarkaID",
                table: "CarDBO",
                column: "MarkaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDBO");

            migrationBuilder.DropTable(
                name: "Markat");
        }
    }
}
