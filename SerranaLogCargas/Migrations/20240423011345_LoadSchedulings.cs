using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerranaLogCargas.Migrations
{
    public partial class LoadSchedulings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoadScheduling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Bol = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CityOriginId = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    CityDestinyId = table.Column<int>(type: "int", nullable: false),
                    DestinyId = table.Column<int>(type: "int", nullable: false),
                    UnloadDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Weigth = table.Column<float>(type: "float", nullable: false),
                    VlTranspor = table.Column<float>(type: "float", nullable: false),
                    VlContract = table.Column<float>(type: "float", nullable: false),
                    Vladvance = table.Column<float>(type: "float", nullable: false),
                    Pay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Cte = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadScheduling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadScheduling_Cities_CityDestinyId",
                        column: x => x.CityDestinyId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadScheduling_Cities_CityOriginId",
                        column: x => x.CityOriginId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoadScheduling_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LoadScheduling_CityDestinyId",
                table: "LoadScheduling",
                column: "CityDestinyId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadScheduling_CityOriginId",
                table: "LoadScheduling",
                column: "CityOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadScheduling_CustomerId",
                table: "LoadScheduling",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadScheduling");
        }
    }
}
