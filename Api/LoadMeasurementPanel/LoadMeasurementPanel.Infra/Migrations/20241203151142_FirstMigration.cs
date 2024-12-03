using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadMeasurementPanel.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumoDiarioPorPonto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasuringPointId = table.Column<long>(type: "bigint", nullable: false),
                    TotalConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoursWithoutRegistration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoDiarioPorPonto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PontosMedicao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosMedicao", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumoDiarioPorPonto");

            migrationBuilder.DropTable(
                name: "PontosMedicao");
        }
    }
}
