using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class Заявки : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "УчастокИд",
                table: "Заявки");

            migrationBuilder.AlterColumn<int>(
                name: "ФормаУчастка",
                table: "Заявки",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Размер1",
                table: "Заявки",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Размер2",
                table: "Заявки",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Заявки_ИдУчастка",
                table: "Заявки",
                column: "ИдУчастка");

            migrationBuilder.AddForeignKey(
                name: "FK_Заявки_УчасткиПолей_ИдУчастка",
                table: "Заявки",
                column: "ИдУчастка",
                principalTable: "УчасткиПолей",
                principalColumn: "Ид",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Заявки_УчасткиПолей_ИдУчастка",
                table: "Заявки");

            migrationBuilder.DropIndex(
                name: "IX_Заявки_ИдУчастка",
                table: "Заявки");

            migrationBuilder.DropColumn(
                name: "Размер1",
                table: "Заявки");

            migrationBuilder.DropColumn(
                name: "Размер2",
                table: "Заявки");

            migrationBuilder.AlterColumn<string>(
                name: "ФормаУчастка",
                table: "Заявки",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ИдПроизводителяСемян",
                table: "Заявки",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "УчастокИд",
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
    }
}
