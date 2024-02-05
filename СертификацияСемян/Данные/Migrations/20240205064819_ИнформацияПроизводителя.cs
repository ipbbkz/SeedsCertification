using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class ИнформацияПроизводителя : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ГодПроизводстваСемян",
                table: "Заявки",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "НаваниеКомпанииПроизводителя",
                table: "Заявки",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ГодПроизводстваСемян",
                table: "Заявки");

            migrationBuilder.DropColumn(
                name: "НаваниеКомпанииПроизводителя",
                table: "Заявки");
        }
    }
}
