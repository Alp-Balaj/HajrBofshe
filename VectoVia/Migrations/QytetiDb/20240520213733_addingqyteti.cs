using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VectoVia.Migrations.QytetiDb
{
    /// <inheritdoc />
    public partial class addingqyteti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qytetet",
                columns: table => new
                {
                    QytetiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emriIQyteti = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qytetet", x => x.QytetiID);
                });

            migrationBuilder.CreateTable(
                name: "KompaniaTaxi",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kompania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigurimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QytetiID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompaniaTaxi", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_KompaniaTaxi_Qytetet_QytetiID",
                        column: x => x.QytetiID,
                        principalTable: "Qytetet",
                        principalColumn: "QytetiID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KompaniaTaxi_QytetiID",
                table: "KompaniaTaxi",
                column: "QytetiID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KompaniaTaxi");

            migrationBuilder.DropTable(
                name: "Qytetet");
        }
    }
}
