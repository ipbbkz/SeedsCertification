using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace СертификацияСемян.Данные;

public class КонтекстБдПриложения : IdentityDbContext
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
    public DbSet<ЗаписьИнспекции> ЗаписиИнспекций { get; set; }
    public DbSet<Анализ> Анализы { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ПроизводительСемян>().HasKey(nameof(ПроизводительСемян.Ид));
        builder.Entity<Заявка>().HasKey(nameof(Заявка.Ид));
        builder.Entity<Поле>().HasKey(nameof(Поле.Ид));
        builder.Entity<УчастокПоля>().HasKey(nameof(УчастокПоля.Ид));
        builder.Entity<Инспекция>().HasKey(nameof(Инспекция.Ид));
        builder.Entity<ЗаписьИнспекции>().HasKey(nameof(ЗаписьИнспекции.Ид));
        builder.Entity<Анализ>().HasKey(nameof(Анализ.Ид));
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
    public byte[] СвидетельствоПроисхожденияСемян { get; set; }
    public byte[] ЗаключениеОНематодах { get; set; }
    public string Протравители { get; set; }
    public string Инсектициды    { get; set; }
    public string Фунгициды { get; set; }
    public string Удобрения { get; set; }
    public string Гербициды { get; set; }
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
}

public class ЗаписьИнспекции
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

public class Анализ
{
    public int Ид { get; set; }
    public int ИнспекцияИд { get; set; }
    public int ТипАнализа { get; set; }
    public int Статус { get; set; }
    public DateTime ДатаСоздания { get; set; } = DateTime.UtcNow;
    public DateTime ДатаОбновления { get; set; } = DateTime.UtcNow;
    public DateTime? ДатаУдаления { get; set; }
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
}