using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addNeighborhoodMissionToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    MissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Reward = table.Column<int>(type: "int", nullable: false),
                    WorldID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.MissionID);
                    table.ForeignKey(
                        name: "FK_Mission_World_WorldID",
                        column: x => x.WorldID,
                        principalTable: "World",
                        principalColumn: "WorldID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhood",
                columns: table => new
                {
                    NeighborhoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    WorldID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhood", x => x.NeighborhoodID);
                    table.ForeignKey(
                        name: "FK_Neighborhood_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Neighborhood_World_WorldID",
                        column: x => x.WorldID,
                        principalTable: "World",
                        principalColumn: "WorldID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mission_WorldID",
                table: "Mission",
                column: "WorldID");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhood_SkillID",
                table: "Neighborhood",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhood_WorldID",
                table: "Neighborhood",
                column: "WorldID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "Neighborhood");
        }
    }
}
