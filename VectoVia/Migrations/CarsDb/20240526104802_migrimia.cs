using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VectoVia.Migrations.CarsDb
{
    /// <inheritdoc />
    public partial class migrimia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Tabelat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modeli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Karburanti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmisioni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VitiProdhimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Tabelat);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
