using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addActProfSkillToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity_RSkills",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    RequieredPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity_RSkills", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_Activity_RSkills_Activity_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activity",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_RSkills_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityImprovesSkill",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityImprovesSkill", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_ActivityImprovesSkill_Activity_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activity",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityImprovesSkill_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profession_Skill",
                columns: table => new
                {
                    ProfessionID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    ScoreLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession_Skill", x => x.ProfessionID);
                    table.ForeignKey(
                        name: "FK_Profession_Skill_Profession_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Profession",
                        principalColumn: "ProfessionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profession_Skill_Skill_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_RSkills_SkillID",
                table: "Activity_RSkills",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityImprovesSkill_SkillID",
                table: "ActivityImprovesSkill",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Profession_Skill_SkillID",
                table: "Profession_Skill",
                column: "SkillID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity_RSkills");

            migrationBuilder.DropTable(
                name: "ActivityImprovesSkill");

            migrationBuilder.DropTable(
                name: "Profession_Skill");
        }
    }
}
