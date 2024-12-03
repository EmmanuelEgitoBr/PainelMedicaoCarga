using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadMeasurementPanel.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PontosMedicao",
                table: "PontosMedicao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsumoDiarioPorPonto",
                table: "ConsumoDiarioPorPonto");

            migrationBuilder.RenameTable(
                name: "PontosMedicao",
                newName: "MeasuringPoints");

            migrationBuilder.RenameTable(
                name: "ConsumoDiarioPorPonto",
                newName: "EnergyConsumptionsPerDay");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasuringPoints",
                table: "MeasuringPoints",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnergyConsumptionsPerDay",
                table: "EnergyConsumptionsPerDay",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasuringPoints",
                table: "MeasuringPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnergyConsumptionsPerDay",
                table: "EnergyConsumptionsPerDay");

            migrationBuilder.RenameTable(
                name: "MeasuringPoints",
                newName: "PontosMedicao");

            migrationBuilder.RenameTable(
                name: "EnergyConsumptionsPerDay",
                newName: "ConsumoDiarioPorPonto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PontosMedicao",
                table: "PontosMedicao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsumoDiarioPorPonto",
                table: "ConsumoDiarioPorPonto",
                column: "Id");
        }
    }
}
