using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addSimProfessionSPToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicePlace",
                columns: table => new
                {
                    PlaceID = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePlace", x => x.PlaceID);
                    table.ForeignKey(
                        name: "FK_ServicePlace_Place_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Place",
                        principalColumn: "PlaceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sim_Profession",
                columns: table => new
                {
                    SimID = table.Column<int>(type: "int", nullable: false),
                    ProfessionID = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sim_Profession", x => x.SimID);
                    table.ForeignKey(
                        name: "FK_Sim_Profession_Profession_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Profession",
                        principalColumn: "ProfessionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sim_Profession_Sim_SimID",
                        column: x => x.SimID,
                        principalTable: "Sim",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sim_Profession_ProfessionID",
                table: "Sim_Profession",
                column: "ProfessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePlace");

            migrationBuilder.DropTable(
                name: "Sim_Profession");
        }
    }
}
