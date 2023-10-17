using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class Удаление : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаОбновления",
                table: "УчасткиПолей",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаСоздания",
                table: "УчасткиПолей",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаУдаления",
                table: "УчасткиПолей",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаОбновления",
                table: "ПроизводителиСемян",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаСоздания",
                table: "ПроизводителиСемян",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаУдаления",
                table: "ПроизводителиСемян",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаОбновления",
                table: "Инспекции",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаУдаления",
                table: "Инспекции",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаОбновления",
                table: "Заявки",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаУдаления",
                table: "Заявки",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаУдаления",
                table: "Анализы",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ДатаОбновления",
                table: "УчасткиПолей");

            migrationBuilder.DropColumn(
                name: "ДатаСоздания",
                table: "УчасткиПолей");

            migrationBuilder.DropColumn(
                name: "ДатаУдаления",
                table: "УчасткиПолей");

            migrationBuilder.DropColumn(
                name: "ДатаОбновления",
                table: "ПроизводителиСемян");

            migrationBuilder.DropColumn(
                name: "ДатаСоздания",
                table: "ПроизводителиСемян");

            migrationBuilder.DropColumn(
                name: "ДатаУдаления",
                table: "ПроизводителиСемян");

            migrationBuilder.DropColumn(
                name: "ДатаОбновления",
                table: "Инспекции");

            migrationBuilder.DropColumn(
                name: "ДатаУдаления",
                table: "Инспекции");

            migrationBuilder.DropColumn(
                name: "ДатаОбновления",
                table: "Заявки");

            migrationBuilder.DropColumn(
                name: "ДатаУдаления",
                table: "Заявки");

            migrationBuilder.DropColumn(
                name: "ДатаУдаления",
                table: "Анализы");
        }
    }
}
