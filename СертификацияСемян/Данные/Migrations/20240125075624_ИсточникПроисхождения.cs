using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class ИсточникПроисхождения : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ИдСертификатаПроисхождения",
                table: "Заявки",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "КодСертификатаПроисхождения",
                table: "Заявки",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "СтранаПроизводитель",
                table: "Заявки",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ИдСертификатаПроисхождения",
                table: "Заявки");

            migrationBuilder.DropColumn(
                name: "КодСертификатаПроисхождения",
                table: "Заявки");

            migrationBuilder.DropColumn(
                name: "СтранаПроизводитель",
                table: "Заявки");
        }
    }
}
