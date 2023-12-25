using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class ДанныеАнализа : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаВзятияОбразца",
                table: "Анализы",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ДатаПередачиВЛабораторию",
                table: "Анализы",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "КоличествоОбразцов",
                table: "Анализы",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ДатаВзятияОбразца",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "ДатаПередачиВЛабораторию",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "КоличествоОбразцов",
                table: "Анализы");
        }
    }
}
