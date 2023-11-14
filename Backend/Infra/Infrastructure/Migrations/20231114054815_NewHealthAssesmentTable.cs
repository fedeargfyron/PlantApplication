using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewHealthAssesmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthAssesments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    PlantImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHealthy = table.Column<bool>(type: "bit", nullable: false),
                    IsHealthyProbability = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiseaseProbability = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiseaseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiseaseCommonNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthAssesments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthAssesments_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthAssesments_PlantId",
                table: "HealthAssesments",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthAssesments");
        }
    }
}
