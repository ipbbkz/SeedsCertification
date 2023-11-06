using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace СертификацияСемян.Данные;

public class МодельЗаявки
{
    [Required]
    public int? ТипЗаявки { get; set; }
    public string НаваниеСортаСемян { get; set; }

    [Required]
    public int? КлассСемянИд { get; set; }

    [Required]
    public int? ИдХозяйства { get; set; }

    [Required]
    public int? ИдПоля { get; set; }

    [Required]
    public int? ИдУчастка { get; set; }

    [Range(15, 65)]
    public int РазмерКлубня { get; set; } = 15;

    public string КоординатыУчастка { get; set; }
    public string СевооборотПрошлогоГода { get; set; }
    public string Севооборот2ГодаНазад { get; set; }
    public string Севооборот3ГодаНазад { get; set; }
    public string ИзоляцияПолей { get; set; }
    public byte[] СвидетельствоПроисхожденияСемян { get; set; }
    public byte[] ЗаключениеОНематодах { get; set; }
    public string? Протравители { get; set; }
    public string? Инсектициды { get; set; }
    public string? Фунгициды { get; set; }
    public string? Удобрения { get; set; }
    public string? Гербициды { get; set; }
    [Required]
    public int? ФормаУчастка { get; set; }
    public string? Размер1 { get; set; }
    public string? Размер2 { get; set; }
    public string ПлощадьПосадки { get; set; }
    public string РасстояниеМеждуРядами { get; set; }
    public string РасстояниеВРяду { get; set; }
    public string ПрогнозируемоеКоличествоУрожая { get; set; }
    public DateTime ДатаПосадки { get; set; } = DateTime.UtcNow;
    public DateTime ДатаСбора { get; set; } = DateTime.UtcNow;
}
