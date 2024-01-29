using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class ЛабораторныеАнализы : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clavibacter",
                table: "Анализы",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PLRV",
                table: "Анализы",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PVA",
                table: "Анализы",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PVM",
                table: "Анализы",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PVS",
                table: "Анализы",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PVX",
                table: "Анализы",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PVY",
                table: "Анализы",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ralstonia",
                table: "Анализы",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clavibacter",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "PLRV",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "PVA",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "PVM",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "PVS",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "PVX",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "PVY",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "Ralstonia",
                table: "Анализы");
        }
    }
}
