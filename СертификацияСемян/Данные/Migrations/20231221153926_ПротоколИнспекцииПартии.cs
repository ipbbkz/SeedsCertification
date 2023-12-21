using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class ПротоколИнспекцииПартии : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ЗаписиИнспекций",
                newName: "ЗаписиПолевыхИнспекций");

            migrationBuilder.CreateTable(
                name: "ЗаписиИнспекцийПартии",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ИнспекцияИд = table.Column<int>(type: "int", nullable: false),
                    ВесПартии = table.Column<int>(type: "int", nullable: false),
                    СухаяГниль = table.Column<int>(type: "int", nullable: true),
                    МокраяГниль = table.Column<int>(type: "int", nullable: true),
                    Фитофтороз = table.Column<int>(type: "int", nullable: true),
                    ПаршаОбыкновенная = table.Column<int>(type: "int", nullable: true),
                    ПаршаЛуговая = table.Column<int>(type: "int", nullable: true),
                    ПаршаСеребристая = table.Column<int>(type: "int", nullable: true),
                    ПаршаПорошистая = table.Column<int>(type: "int", nullable: true),
                    Продавленность = table.Column<int>(type: "int", nullable: true),
                    НезначительныеПовреждения = table.Column<int>(type: "int", nullable: true),
                    ВнешниеДефекты = table.Column<int>(type: "int", nullable: true),
                    ПрилипшаяПочва = table.Column<int>(type: "int", nullable: true),
                    ПревышениеРазмеров = table.Column<int>(type: "int", nullable: true),
                    Проростания = table.Column<int>(type: "int", nullable: true),
                    ВнутренниеДефекты = table.Column<int>(type: "int", nullable: true),
                    РаздавленныеКлубни = table.Column<int>(type: "int", nullable: true),
                    ВирусныйНекроз = table.Column<int>(type: "int", nullable: true),
                    Переохлаждение = table.Column<int>(type: "int", nullable: true),
                    Вредители = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ЗаписиИнспекцийПартии", x => x.Ид);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ЗаписиИнспекцийПартии");

            migrationBuilder.RenameTable(
                name: "ЗаписиПолевыхИнспекций",
                newName: "ЗаписиИнспекций");
        }
    }
}
