using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class ФайлАнализа : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ФайлСАнализами",
                table: "Анализы",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Инспекции_ЗаявкаИд",
                table: "Инспекции",
                column: "ЗаявкаИд");

            migrationBuilder.CreateIndex(
                name: "IX_Анализы_ИнспекцияИд",
                table: "Анализы",
                column: "ИнспекцияИд");

            migrationBuilder.AddForeignKey(
                name: "FK_Анализы_Инспекции_ИнспекцияИд",
                table: "Анализы",
                column: "ИнспекцияИд",
                principalTable: "Инспекции",
                principalColumn: "Ид",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Инспекции_Заявки_ЗаявкаИд",
                table: "Инспекции",
                column: "ЗаявкаИд",
                principalTable: "Заявки",
                principalColumn: "Ид",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Анализы_Инспекции_ИнспекцияИд",
                table: "Анализы");

            migrationBuilder.DropForeignKey(
                name: "FK_Инспекции_Заявки_ЗаявкаИд",
                table: "Инспекции");

            migrationBuilder.DropIndex(
                name: "IX_Инспекции_ЗаявкаИд",
                table: "Инспекции");

            migrationBuilder.DropIndex(
                name: "IX_Анализы_ИнспекцияИд",
                table: "Анализы");

            migrationBuilder.DropColumn(
                name: "ФайлСАнализами",
                table: "Анализы");
        }
    }
}
