using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class ИдХозяйстваДляУчастка : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ИдХозяйства",
                table: "УчасткиПолей",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_УчасткиПолей_ИдХозяйства",
                table: "УчасткиПолей",
                column: "ИдХозяйства");

            migrationBuilder.AddForeignKey(
                name: "FK_УчасткиПолей_ПроизводителиСемян_ИдХозяйства",
                table: "УчасткиПолей",
                column: "ИдХозяйства",
                principalTable: "ПроизводителиСемян",
                principalColumn: "Ид",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_УчасткиПолей_ПроизводителиСемян_ИдХозяйства",
                table: "УчасткиПолей");

            migrationBuilder.DropIndex(
                name: "IX_УчасткиПолей_ИдХозяйства",
                table: "УчасткиПолей");

            migrationBuilder.DropColumn(
                name: "ИдХозяйства",
                table: "УчасткиПолей");
        }
    }
}
