using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class ПроданнаяПартия : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "СертифицированныеПартии",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ВесПартии = table.Column<int>(type: "int", nullable: false),
                    ДатаВыпуска = table.Column<DateTime>(type: "datetime2", nullable: false),
                    СертификатИд = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_СертифицированныеПартии", x => x.Ид);
                    table.ForeignKey(
                        name: "FK_СертифицированныеПартии_Сертификаты_СертификатИд",
                        column: x => x.СертификатИд,
                        principalTable: "Сертификаты",
                        principalColumn: "Ид",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_СертифицированныеПартии_СертификатИд",
                table: "СертифицированныеПартии",
                column: "СертификатИд");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "СертифицированныеПартии");
        }
    }
}
