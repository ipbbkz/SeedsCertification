using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class Сертификаты : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Сертификаты",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ЗаявкаИд = table.Column<int>(type: "int", nullable: false),
                    ДатаВыпуска = table.Column<DateTime>(type: "datetime2", nullable: false),
                    КлассСемянИд = table.Column<int>(type: "int", nullable: false),
                    ВаловыйПродукт = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сертификаты", x => x.Ид);
                    table.ForeignKey(
                        name: "FK_Сертификаты_Заявки_ЗаявкаИд",
                        column: x => x.ЗаявкаИд,
                        principalTable: "Заявки",
                        principalColumn: "Ид",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Сертификаты_ЗаявкаИд",
                table: "Сертификаты",
                column: "ЗаявкаИд");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Сертификаты");
        }
    }
}
