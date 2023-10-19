using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class Поля : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_УчасткиПолей_ПроизводителиСемян_ИдХозяйства",
                table: "УчасткиПолей");

            migrationBuilder.DropColumn(
                name: "ПравоустанавливающиеДокументы",
                table: "УчасткиПолей");

            migrationBuilder.RenameColumn(
                name: "ИдХозяйства",
                table: "УчасткиПолей",
                newName: "ИдПоля");

            migrationBuilder.RenameColumn(
                name: "АдресУчастка",
                table: "УчасткиПолей",
                newName: "КоординатыУчастка");

            migrationBuilder.RenameIndex(
                name: "IX_УчасткиПолей_ИдХозяйства",
                table: "УчасткиПолей",
                newName: "IX_УчасткиПолей_ИдПоля");

            migrationBuilder.CreateTable(
                name: "Поля",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ИдХозяйства = table.Column<int>(type: "int", nullable: false),
                    Название = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    АдресПоля = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ПравоустанавливающиеДокументы = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Активно = table.Column<bool>(type: "bit", nullable: false),
                    ДатаСоздания = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ДатаОбновления = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ДатаУдаления = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Поля", x => x.Ид);
                    table.ForeignKey(
                        name: "FK_Поля_ПроизводителиСемян_ИдХозяйства",
                        column: x => x.ИдХозяйства,
                        principalTable: "ПроизводителиСемян",
                        principalColumn: "Ид",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Поля_ИдХозяйства",
                table: "Поля",
                column: "ИдХозяйства");

            migrationBuilder.AddForeignKey(
                name: "FK_УчасткиПолей_Поля_ИдПоля",
                table: "УчасткиПолей",
                column: "ИдПоля",
                principalTable: "Поля",
                principalColumn: "Ид",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_УчасткиПолей_Поля_ИдПоля",
                table: "УчасткиПолей");

            migrationBuilder.DropTable(
                name: "Поля");

            migrationBuilder.RenameColumn(
                name: "КоординатыУчастка",
                table: "УчасткиПолей",
                newName: "АдресУчастка");

            migrationBuilder.RenameColumn(
                name: "ИдПоля",
                table: "УчасткиПолей",
                newName: "ИдХозяйства");

            migrationBuilder.RenameIndex(
                name: "IX_УчасткиПолей_ИдПоля",
                table: "УчасткиПолей",
                newName: "IX_УчасткиПолей_ИдХозяйства");

            migrationBuilder.AddColumn<byte[]>(
                name: "ПравоустанавливающиеДокументы",
                table: "УчасткиПолей",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_УчасткиПолей_ПроизводителиСемян_ИдХозяйства",
                table: "УчасткиПолей",
                column: "ИдХозяйства",
                principalTable: "ПроизводителиСемян",
                principalColumn: "Ид",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
