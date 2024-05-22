using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vectovia.Migrations
{
    /// <inheritdoc />
    public partial class Altin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qytetet",
                columns: table => new
                {
                    QytetiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qytetet", x => x.QytetiId);
                });

            migrationBuilder.CreateTable(
                name: "KompaniaTaksive",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kompania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigurimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QytetiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompaniaTaksive", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_KompaniaTaksive_Qytetet_QytetiId",
                        column: x => x.QytetiId,
                        principalTable: "Qytetet",
                        principalColumn: "QytetiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KompaniaTaksive_QytetiId",
                table: "KompaniaTaksive",
                column: "QytetiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KompaniaTaksive");

            migrationBuilder.DropTable(
                name: "Qytetet");
        }
    }
}
