using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vectovia.Migrations
{
    /// <inheritdoc />
    public partial class migrimiA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KompaniaTaxis",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kompania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigurimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qyteti = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompaniaTaxis", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Qytetis",
                columns: table => new
                {
                    QytetiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qytetis", x => x.QytetiId);
                });

            migrationBuilder.CreateTable(
                name: "KompaniaTaxiQytetis",
                columns: table => new
                {
                    KompaniaTaxiId = table.Column<int>(type: "int", nullable: false),
                    QytetiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompaniaTaxiQytetis", x => new { x.KompaniaTaxiId, x.QytetiId });
                    table.ForeignKey(
                        name: "FK_KompaniaTaxiQytetis_KompaniaTaxis_KompaniaTaxiId",
                        column: x => x.KompaniaTaxiId,
                        principalTable: "KompaniaTaxis",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KompaniaTaxiQytetis_Qytetis_QytetiId",
                        column: x => x.QytetiId,
                        principalTable: "Qytetis",
                        principalColumn: "QytetiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KompaniaTaxiQytetis_QytetiId",
                table: "KompaniaTaxiQytetis",
                column: "QytetiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KompaniaTaxiQytetis");

            migrationBuilder.DropTable(
                name: "KompaniaTaxis");

            migrationBuilder.DropTable(
                name: "Qytetis");
        }
    }
}
