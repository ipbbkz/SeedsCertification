using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace СертификацияСемян.Данные;

public class КонтекстБдПриложения : IdentityDbContext<ПользовательПриложения>
{
    public КонтекстБдПриложения(DbContextOptions<КонтекстБдПриложения> options)
        : base(options)
    {
    }

    public DbSet<ПроизводительСемян> ПроизводителиСемян { get; set; }
    public DbSet<Заявка> Заявки { get; set; }
    public DbSet<Поле> Поля { get; set; }
    public DbSet<УчастокПоля> УчасткиПолей { get; set; }
    public DbSet<Инспекция> Инспекции { get; set; }
    public DbSet<ЗаписьПолевойИнспекции> ЗаписиПолевыхИнспекций { get; set; }
    public DbSet<ЗаписьИнспекцииПартии> ЗаписиИнспекцийПартии { get; set; }
    public DbSet<Анализ> Анализы { get; set; }
    public DbSet<Сертификат> Сертификаты { get; set; }
    public DbSet<СертифицированнаяПартия> СертифицированныеПартии { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ПроизводительСемян>().HasKey(nameof(ПроизводительСемян.Ид));
        builder.Entity<Заявка>().HasKey(nameof(Заявка.Ид));
        builder.Entity<Поле>().HasKey(nameof(Поле.Ид));
        builder.Entity<УчастокПоля>().HasKey(nameof(УчастокПоля.Ид));
        builder.Entity<Инспекция>().HasKey(nameof(Инспекция.Ид));
        builder.Entity<ЗаписьПолевойИнспекции>().HasKey(nameof(ЗаписьПолевойИнспекции.Ид));
        builder.Entity<ЗаписьИнспекцииПартии>().HasKey(nameof(ЗаписьИнспекцииПартии.Ид));
        builder.Entity<Анализ>().HasKey(nameof(Анализ.Ид));
        builder.Entity<Сертификат>().HasKey(nameof(Сертификат.Ид));
        builder.Entity<СертифицированнаяПартия>().HasKey(nameof(СертифицированнаяПартия.Ид));

        builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole() { Id = Константы.РольАдминистратора, Name = Константы.РольАдминистратора, NormalizedName = Константы.РольАдминистратора.ToUpperInvariant() },
                new IdentityRole() { Id = Константы.РольИнспектора, Name = Константы.РольИнспектора, NormalizedName = Константы.РольИнспектора.ToUpperInvariant() },
                new IdentityRole() { Id = Константы.РольСтаршийИнспектор, Name = Константы.РольСтаршийИнспектор, NormalizedName = Константы.РольСтаршийИнспектор.ToUpperInvariant() },
                new IdentityRole() { Id = Константы.РольЛаборатория, Name = Константы.РольЛаборатория, NormalizedName = Константы.РольЛаборатория.ToUpperInvariant() },
                new IdentityRole() { Id = Константы.РольРуководительСертификационнойСлужбы, Name = Константы.РольРуководительСертификационнойСлужбы, NormalizedName = Константы.РольРуководительСертификационнойСлужбы.ToUpperInvariant() },
                new IdentityRole() { Id = Константы.РольФермер, Name = Константы.РольФермер, NormalizedName = Константы.РольФермер.ToUpperInvariant() });
        base.OnModelCreating(builder);
    }
}

public class Заявка
{
    public int Ид { get; set; }
    public int ИдУчастка { get; set; }

    public int ТипЗаявки { get; set; }
    public string НаваниеСортаСемян { get; set; }

    public int КлассСемянИд { get; set; }

    public int РазмерКлубня { get; set; }

    public string КоординатыУчастка { get; set; }
    public string СевооборотПрошлогоГода { get; set; }
    public string Севооборот2ГодаНазад { get; set; }
    public string Севооборот3ГодаНазад { get; set; }
    public string ИзоляцияПолей { get; set; }
    public string СтранаПроизводитель { get; set; }
    public byte[] СвидетельствоПроисхожденияСемян { get; set; }
    public string КодСертификатаПроисхождения { get; set; }
    public int? ИдСертификатаПроисхождения { get; set; }
    public byte[] ЗаключениеОНематодах { get; set; }
    public string? Протравители { get; set; }
    public string? Инсектициды    { get; set; }
    public string? Фунгициды { get; set; }
    public string? Удобрения { get; set; }
    public string? Гербициды { get; set; }
    public int ФормаУчастка { get; set; }
    public string? Размер1 { get; set; }
    public string? Размер2 { get; set; }
    public string ПлощадьПосадки { get; set; }
    public string РасстояниеМеждуРядами { get; set; }
    public string РасстояниеВРяду { get; set; }
    public string ПрогнозируемоеКоличествоУрожая { get; set; }
    public DateTime ДатаПосадки { get; set; }
    public DateTime ДатаСбора { get; set; }
    public bool Активно { get; set; }
    public int Статус { get; set; }
    public DateTime ДатаСоздания { get; set; } = DateTime.UtcNow;
    public DateTime ДатаОбновления { get; set; } = DateTime.UtcNow;
    public DateTime? ДатаУдаления { get; set; }

    [ForeignKey("ИдУчастка")]
    public УчастокПоля УчастокПоля { get; set; }

    [NotMapped]
    public string Код => $"У{Ид:0000}/{(ДатаСоздания.Year % 100)}";
}

public class Поле
{
    public int Ид { get; set; }
    public int ИдХозяйства { get; set; }
    public string Название { get; set; }
    public string АдресПоля { get; set; }
    public byte[] ПравоустанавливающиеДокументы { get; set; }
    public bool Активно { get; set; }
    public DateTime ДатаСоздания { get; set; } = DateTime.UtcNow;
    public DateTime ДатаОбновления { get; set; } = DateTime.UtcNow;
    public DateTime? ДатаУдаления { get; set; }

    [ForeignKey(nameof(ИдХозяйства))]
    public ПроизводительСемян ПроизводительСемян { get; set; }
}

public class УчастокПоля
{
    public int Ид { get; set; }
    public int ИдПоля { get; set; }
    public string Название { get; set; }
    public string КоординатыУчастка { get; set; }
    public bool Активно { get; set; }
    public DateTime ДатаСоздания { get; set; } = DateTime.UtcNow;
    public DateTime ДатаОбновления { get; set; } = DateTime.UtcNow;
    public DateTime? ДатаУдаления { get; set; }

    [ForeignKey(nameof(ИдПоля))]
    public Поле Поле { get; set; }
}

public class Инспекция
{
    public int Ид { get; set; }
    public int Статус { get; set; }
    public int ЗаявкаИд { get; set; }
    public int ТипИнспекции { get; set; }
    public DateTime ПланируемаяДата { get; set; }
    public DateTime? ФактическаяДата { get; set; }
    public string ФизиологическаяСтадия { get; set; }
    public string ОбщиеУсловияПоля { get; set; }
    public string ИмяВедущегоИнспектора { get; set; }
    public string ДругиеИнспектора { get; set; }
    public int ЦелевойНачальныйПорог { get; set; }
    public string? ПричинаОтказа { get; set; }
    public DateTime ДатаСоздания { get; set; } = DateTime.UtcNow;
    public DateTime ДатаОбновления { get; set; } = DateTime.UtcNow;
    public DateTime? ДатаУдаления { get; set; }

    [ForeignKey(nameof(ЗаявкаИд))]
    public Заявка Заявка { get; set; }
}

public class ЗаписьПолевойИнспекции
{
    public int Ид { get; set; }
    public int ИнспекцияИд { get; set; }
    public int НомерСерии { get; set; }
    public int КоличествоРастенийВСерии { get; set; }
    public int? Карантин { get; set; }
    public int? ВиральныеБолезни { get; set; }
    public int? Черноножка { get; set; }
    public int? Безтиповые { get; set; }
    public int? Ризоктония { get; set; }
}

public class ЗаписьИнспекцииПартии
{
    public int Ид { get; set; }
    public int ИнспекцияИд { get; set; }
    public int ВесПартии { get; set; }
    public double? СухаяГниль { get; set; }
    public double? МокраяГниль { get; set; }
    public double? Фитофтороз { get; set; }
    public double? ПаршаОбыкновенная { get; set; }
    public double? ПаршаЛуговая { get; set; }
    public double? ПаршаСеребристая { get; set; }
    public double? ПаршаПорошистая { get; set; }
    public double? Продавленность { get; set; }
    public double? НезначительныеПовреждения { get; set; } // ignore
    public double? ВнешниеДефекты { get; set; }
    public double? ПрилипшаяПочва { get; set; }
    public double? ПревышениеРазмеров { get; set; }
    public double? Проростания { get; set; } // ignore
    public double? ВнутренниеДефекты { get; set; } // ignore
    public double? РаздавленныеКлубни { get; set; }
    public double? ВирусныйНекроз { get; set; } // ignore
    public double? Переохлаждение { get; set; }
    public double? Вредители { get; set; }
    public double? Ризоктониоз { get; set; }
    [NotMapped]
    public int ИнспектируемыйВес
    {
        get
        {
            return ВесПартии switch
            {
                <= 50_000 => 100,
                > 50_000 and <= 150_000 => 150,
                > 150_000 and <= 300_000 => 200,
                > 300_000 and <= 500_000 => 300,
                > 500_000 and <= 800_000 => 400,
                _ => 400
            };
        }
    }
    [NotMapped]
    public double? ВесДефектов
    {
        get
        {
            return СухаяГниль + МокраяГниль + Фитофтороз + ПаршаОбыкновенная + ПаршаЛуговая + ПаршаСеребристая
                + ПаршаПорошистая
                + Продавленность
                + ПрилипшаяПочва
                + ПревышениеРазмеров
                + ВнешниеДефекты
                + РаздавленныеКлубни
                + Переохлаждение
                + Вредители
                + Ризоктониоз;
        }
    }
}

public class Анализ
{
    public int Ид { get; set; }
    public int ИнспекцияИд { get; set; }
    public int ТипАнализа { get; set; }
    public int Статус { get; set; }
    public byte[]? ФайлСАнализами { get; set; }
    public int КоличествоОбразцов { get; set; }
    public DateTime ДатаВзятияОбразца { get; set; }
    public DateTime ДатаПередачиВЛабораторию { get; set; }
    public DateTime ДатаСоздания { get; set; } = DateTime.UtcNow;
    public DateTime ДатаОбновления { get; set; } = DateTime.UtcNow;
    public DateTime? ДатаУдаления { get; set; }
    public int? PLRV { get; set; }
    public int? PVA { get; set; }
    public int? PVM { get; set; }
    public int? PVX { get; set; }
    public int? PVY { get; set; }
    public int? PVS { get; set; }
    public int? Clavibacter { get; set; }
    public int? Ralstonia { get; set; }

    [ForeignKey(nameof(ИнспекцияИд))]
    public Инспекция Инспекция { get; set; }
}

public class ПроизводительСемян
{
    public int Ид { get; set; }
    public string ИдВладельца { get; set; }
    public int ФормаХозяйствования { get; set; }
    public string НаваниеКомпании { get; set; }
    public string БинИлиИин { get; set; }
    public string ЮридическийАдрес { get; set; }
    public string КонтактноеЛицо { get; set; }
    public string ЭлектроннаяПочтаКонтактногоЛица { get; set; }
    public string НомерТелефонаКонтактногоЛица { get; set; }
    public bool Активно { get; set; }
    public DateTime ДатаСоздания { get; set; } = DateTime.UtcNow;
    public DateTime ДатаОбновления { get; set; } = DateTime.UtcNow;
    public DateTime? ДатаУдаления { get; set; }

    [NotMapped]
    public string Код => $"Ш{Ид:0000}";
}

public class Сертификат
{
    public int Ид { get; set; }
    public int ЗаявкаИд { get; set; }
    public DateTime ДатаВыпуска { get; set; }
    public int КлассСемянИд { get; set; }
    public int ВаловыйПродукт { get; set; }

    [ForeignKey(nameof(ЗаявкаИд))]
    public Заявка Заявка { get; set; }
}

public class СертифицированнаяПартия
{
    public int Ид { get; set; }
    public int ВесПартии { get; set; }
    public DateTime ДатаВыпуска { get; set; }
    public int СертификатИд { get; set; }

    [ForeignKey(nameof(СертификатИд))]
    public Сертификат Сертификат { get; set; }
}