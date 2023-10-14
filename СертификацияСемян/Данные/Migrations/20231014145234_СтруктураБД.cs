using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace СертификацияСемян.Данные.Migrations
{
    /// <inheritdoc />
    public partial class СтруктураБД : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Анализы",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ИнспекцияИд = table.Column<int>(type: "int", nullable: false),
                    ТипАнализа = table.Column<int>(type: "int", nullable: false),
                    Статус = table.Column<int>(type: "int", nullable: false),
                    ДатаСоздания = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ДатаОбновления = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Анализы", x => x.Ид);
                });

            migrationBuilder.CreateTable(
                name: "ЗаписиИнспекций",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ИнспекцияИд = table.Column<int>(type: "int", nullable: false),
                    НомерСерии = table.Column<int>(type: "int", nullable: false),
                    КоличествоРастенийВСерии = table.Column<int>(type: "int", nullable: false),
                    Карантин = table.Column<int>(type: "int", nullable: true),
                    ВиральныеБолезни = table.Column<int>(type: "int", nullable: true),
                    Черноножка = table.Column<int>(type: "int", nullable: true),
                    Безтиповые = table.Column<int>(type: "int", nullable: true),
                    Ризоктония = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ЗаписиИнспекций", x => x.Ид);
                });

            migrationBuilder.CreateTable(
                name: "Заявки",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ТипЗаявки = table.Column<int>(type: "int", nullable: false),
                    НаваниеСортаСемян = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    КлассСемянИд = table.Column<int>(type: "int", nullable: false),
                    УчастокИд = table.Column<int>(type: "int", nullable: false),
                    РазмерКлубня = table.Column<int>(type: "int", nullable: false),
                    КоординатыУчастка = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    СевооборотПрошлогоГода = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Севооборот2ГодаНазад = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Севооборот3ГодаНазад = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ИзоляцияПолей = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    СвидетельствоПроисхожденияСемян = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ЗаключениеОНематодах = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Протравители = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Инсектициды = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Фунгициды = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Удобрения = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Гербициды = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ФормаУчастка = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ПлощадьПосадки = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    РасстояниеМеждуРядами = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    РасстояниеВРяду = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ПрогнозируемоеКоличествоУрожая = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ДатаПосадки = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ДатаСбора = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Активно = table.Column<bool>(type: "bit", nullable: false),
                    Статус = table.Column<int>(type: "int", nullable: false),
                    ДатаСоздания = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Заявки", x => x.Ид);
                });

            migrationBuilder.CreateTable(
                name: "Инспекции",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Статус = table.Column<int>(type: "int", nullable: false),
                    ЗаявкаИд = table.Column<int>(type: "int", nullable: false),
                    ТипИнспекции = table.Column<int>(type: "int", nullable: false),
                    ПланируемаяДата = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ФактическаяДата = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ФизиологическаяСтадия = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ОбщиеУсловияПоля = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ИмяВедущегоИнспектора = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ДругиеИнспектора = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ЦелевойНачальныйПорог = table.Column<int>(type: "int", nullable: false),
                    ПричинаОтказа = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ДатаСоздания = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Инспекции", x => x.Ид);
                });

            migrationBuilder.CreateTable(
                name: "ПроизводителиСемян",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ФормаХозяйствования = table.Column<int>(type: "int", nullable: false),
                    НаваниеКомпании = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    БинИлиИин = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ЮридическийАдрес = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    КонтактноеЛицо = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ЭлектроннаяПочтаКонтактногоЛица = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    НомерТелефонаКонтактногоЛица = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Активно = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ПроизводителиСемян", x => x.Ид);
                });

            migrationBuilder.CreateTable(
                name: "УчасткиПолей",
                columns: table => new
                {
                    Ид = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    АдресУчастка = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ПравоустанавливающиеДокументы = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Активно = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_УчасткиПолей", x => x.Ид);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Анализы");

            migrationBuilder.DropTable(
                name: "ЗаписиИнспекций");

            migrationBuilder.DropTable(
                name: "Заявки");

            migrationBuilder.DropTable(
                name: "Инспекции");

            migrationBuilder.DropTable(
                name: "ПроизводителиСемян");

            migrationBuilder.DropTable(
                name: "УчасткиПолей");
        }
    }
}
