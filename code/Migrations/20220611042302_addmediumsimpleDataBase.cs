using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class addmediumsimpleDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity_RSkills",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    HomeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeighborhoodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.HomeID);
                    table.ForeignKey(
                        name: "FK_Home_Neighborhood_NeighborhoodID",
                        column: x => x.NeighborhoodID,
                        principalTable: "Neighborhood",
                        principalColumn: "NeighborhoodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeighborhoodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceID);
                    table.ForeignKey(
                        name: "FK_Place_Neighborhood_NeighborhoodID",
                        column: x => x.NeighborhoodID,
                        principalTable: "Neighborhood",
                        principalColumn: "NeighborhoodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Home_NeighborhoodID",
                table: "Home",
                column: "NeighborhoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Place_NeighborhoodID",
                table: "Place",
                column: "NeighborhoodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity_RSkills");

            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropTable(
                name: "Place");
        }
    }
}
