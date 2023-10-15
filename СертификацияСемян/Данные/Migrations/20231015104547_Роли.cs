using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class Роли : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Администратор", null, "Администратор", "АДМИНИСТРАТОР" },
                    { "Инспектор", null, "Инспектор", "ИНСПЕКТОР" },
                    { "Лаборатория", null, "Лаборатория", "ЛАБОРАТОРИЯ" },
                    { "РуководительСертификационнойСлужбы", null, "РуководительСертификационнойСлужбы", "РУКОВОДИТЕЛЬСЕРТИФИКАЦИОННОЙСЛУЖБЫ" },
                    { "СтаршийИнспектор", null, "СтаршийИнспектор", "СТАРШИЙИНСПЕКТОР" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Администратор");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Инспектор");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Лаборатория");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "РуководительСертификационнойСлужбы");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "СтаршийИнспектор");
        }
    }
}
