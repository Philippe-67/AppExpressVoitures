using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppExpressVoitures.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    VinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateVente = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrixAchat = table.Column<float>(type: "real", nullable: false),
                    PrixVente = table.Column<float>(type: "real", nullable: false),
                    VoitureDisponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.VinID);
                });

            migrationBuilder.CreateTable(
                name: "Reparations",
                columns: table => new
                {
                    ReparationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePriseEnCharge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDelivrance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VinId = table.Column<int>(type: "int", nullable: false),
                    VoitureVinID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparations", x => x.ReparationId);
                    table.ForeignKey(
                        name: "FK_Reparations_Voitures_VoitureVinID",
                        column: x => x.VoitureVinID,
                        principalTable: "Voitures",
                        principalColumn: "VinID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_VoitureVinID",
                table: "Reparations",
                column: "VoitureVinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reparations");

            migrationBuilder.DropTable(
                name: "Voitures");
        }
    }
}
