using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vectovia.Migrations.KompaniaRentDb
{
    /// <inheritdoc />
    public partial class AddedQyteti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qyteti",
                table: "KompaniaRents");

            migrationBuilder.AddColumn<int>(
                name: "QytetiId",
                table: "KompaniaRents",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_KompaniaRents_QytetiId",
                table: "KompaniaRents",
                column: "QytetiId");

            migrationBuilder.CreateIndex(
                name: "IX_KompaniaTaxi_QytetiId",
                table: "KompaniaTaxi",
                column: "QytetiId");

            migrationBuilder.AddForeignKey(
                name: "FK_KompaniaRents_Qyteti_QytetiId",
                table: "KompaniaRents",
                column: "QytetiId",
                principalTable: "Qyteti",
                principalColumn: "QytetiId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KompaniaRents_Qyteti_QytetiId",
                table: "KompaniaRents");

            migrationBuilder.DropTable(
                name: "KompaniaTaxi");

            migrationBuilder.DropTable(
                name: "Qyteti");

            migrationBuilder.DropIndex(
                name: "IX_KompaniaRents_QytetiId",
                table: "KompaniaRents");

            migrationBuilder.DropColumn(
                name: "QytetiId",
                table: "KompaniaRents");

            migrationBuilder.AddColumn<string>(
                name: "Qyteti",
                table: "KompaniaRents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
