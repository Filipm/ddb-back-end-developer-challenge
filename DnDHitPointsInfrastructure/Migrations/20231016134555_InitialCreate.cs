using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDHitPointsInfrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HitPoints",
                columns: table => new
                {
                    CharacterName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentHitPoints = table.Column<int>(type: "int", nullable: false),
                    TemporaryHitPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HitPoints", x => x.CharacterName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HitPoints_CharacterName",
                table: "HitPoints",
                column: "CharacterName");            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HitPoints");
        }
    }
}
