using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addMissionActSimSkillTravelerToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mission_Requieres_Skills",
                columns: table => new
                {
                    MissionID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    MissiondID = table.Column<int>(type: "int", nullable: true),
                    RequieredPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission_Requieres_Skills", x => new { x.MissionID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_Mission_Requieres_Skills_Mission_MissiondID",
                        column: x => x.MissiondID,
                        principalTable: "Mission",
                        principalColumn: "MissionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mission_Requieres_Skills_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sim_Activity",
                columns: table => new
                {
                    SimID = table.Column<int>(type: "int", nullable: false),
                    ActivityID = table.Column<int>(type: "int", nullable: false),
                    LastDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sim_Activity", x => new { x.SimID, x.ActivityID });
                    table.ForeignKey(
                        name: "FK_Sim_Activity_Activity_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activity",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sim_Activity_Sim_SimID",
                        column: x => x.SimID,
                        principalTable: "Sim",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sim_Skill",
                columns: table => new
                {
                    SimID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sim_Skill", x => new { x.SimID, x.SkillID });
                    table.ForeignKey(
                        name: "FK_Sim_Skill_Sim_SimID",
                        column: x => x.SimID,
                        principalTable: "Sim",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sim_Skill_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traveler",
                columns: table => new
                {
                    SimID = table.Column<int>(type: "int", nullable: false),
                    WorldID = table.Column<int>(type: "int", nullable: false),
                    DateID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traveler", x => new { x.SimID, x.WorldID, x.DateID });
                    table.ForeignKey(
                        name: "FK_Traveler_Date_DateID",
                        column: x => x.DateID,
                        principalTable: "Date",
                        principalColumn: "DateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traveler_Sim_SimID",
                        column: x => x.SimID,
                        principalTable: "Sim",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traveler_World_WorldID",
                        column: x => x.WorldID,
                        principalTable: "World",
                        principalColumn: "WorldID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traveler_Mission_Date",
                columns: table => new
                {
                    SimID = table.Column<int>(type: "int", nullable: false),
                    MissionID = table.Column<int>(type: "int", nullable: false),
                    DateID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MissiondID = table.Column<int>(type: "int", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traveler_Mission_Date", x => new { x.SimID, x.MissionID, x.DateID });
                    table.ForeignKey(
                        name: "FK_Traveler_Mission_Date_Date_DateID",
                        column: x => x.DateID,
                        principalTable: "Date",
                        principalColumn: "DateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traveler_Mission_Date_Mission_MissiondID",
                        column: x => x.MissiondID,
                        principalTable: "Mission",
                        principalColumn: "MissionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Traveler_Mission_Date_Sim_SimID",
                        column: x => x.SimID,
                        principalTable: "Sim",
                        principalColumn: "SimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Requieres_Skills_MissiondID",
                table: "Mission_Requieres_Skills",
                column: "MissiondID");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_Requieres_Skills_SkillID",
                table: "Mission_Requieres_Skills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Sim_Activity_ActivityID",
                table: "Sim_Activity",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Sim_Skill_SkillID",
                table: "Sim_Skill",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Traveler_DateID",
                table: "Traveler",
                column: "DateID");

            migrationBuilder.CreateIndex(
                name: "IX_Traveler_WorldID",
                table: "Traveler",
                column: "WorldID");

            migrationBuilder.CreateIndex(
                name: "IX_Traveler_Mission_Date_DateID",
                table: "Traveler_Mission_Date",
                column: "DateID");

            migrationBuilder.CreateIndex(
                name: "IX_Traveler_Mission_Date_MissiondID",
                table: "Traveler_Mission_Date",
                column: "MissiondID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mission_Requieres_Skills");

            migrationBuilder.DropTable(
                name: "Sim_Activity");

            migrationBuilder.DropTable(
                name: "Sim_Skill");

            migrationBuilder.DropTable(
                name: "Traveler");

            migrationBuilder.DropTable(
                name: "Traveler_Mission_Date");
        }
    }
}
