using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addPetSimToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    PetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetTypeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HomeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.PetID);
                    table.ForeignKey(
                        name: "FK_Pet_Home_HomeID",
                        column: x => x.HomeID,
                        principalTable: "Home",
                        principalColumn: "HomeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pet_PetType_PetTypeID",
                        column: x => x.PetTypeID,
                        principalTable: "PetType",
                        principalColumn: "PetTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sim",
                columns: table => new
                {
                    SimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeID = table.Column<int>(type: "int", nullable: false),
                    LifeStageID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GenderID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sim", x => x.SimID);
                    table.ForeignKey(
                        name: "FK_Sim_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sim_Home_HomeID",
                        column: x => x.HomeID,
                        principalTable: "Home",
                        principalColumn: "HomeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sim_LifeStage_LifeStageID",
                        column: x => x.LifeStageID,
                        principalTable: "LifeStage",
                        principalColumn: "LifeStageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_HomeID",
                table: "Pet",
                column: "HomeID");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_PetTypeID",
                table: "Pet",
                column: "PetTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sim_GenderID",
                table: "Sim",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Sim_HomeID",
                table: "Sim",
                column: "HomeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sim_LifeStageID",
                table: "Sim",
                column: "LifeStageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Sim");
        }
    }
}
