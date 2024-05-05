using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogCargas.Migrations
{
    public partial class Loadothers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckList",
                table: "LoadScheduling",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Monitoring",
                table: "LoadScheduling",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RiskManagement",
                table: "LoadScheduling",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleType",
                table: "LoadScheduling",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckList",
                table: "LoadScheduling");

            migrationBuilder.DropColumn(
                name: "Monitoring",
                table: "LoadScheduling");

            migrationBuilder.DropColumn(
                name: "RiskManagement",
                table: "LoadScheduling");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "LoadScheduling");
        }
    }
}
