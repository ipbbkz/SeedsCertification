using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class СсылкаНаПроизводителя : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ИдПроизводителяСемян",
                table: "Заявки",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Заявки_ИдПроизводителяСемян",
                table: "Заявки",
                column: "ИдПроизводителяСемян");

            migrationBuilder.AddForeignKey(
                name: "FK_Заявки_ПроизводителиСемян_ИдПроизводителяСемян",
                table: "Заявки",
                column: "ИдПроизводителяСемян",
                principalTable: "ПроизводителиСемян",
                principalColumn: "Ид",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Заявки_ПроизводителиСемян_ИдПроизводителяСемян",
                table: "Заявки");

            migrationBuilder.DropIndex(
                name: "IX_Заявки_ИдПроизводителяСемян",
                table: "Заявки");

            migrationBuilder.DropColumn(
                name: "ИдПроизводителяСемян",
                table: "Заявки");
        }
    }
}
