﻿using System.ComponentModel.DataAnnotations;

namespace СертификацияСемян.Данные;

public class МодельЗаявки
{
    public int Ид { get; set; }

    [Обязательное]
    public int? ТипЗаявки { get; set; }

    public string Код { get; set; }

    public string НазваниеСортаСемян { get; set; }

    [Обязательное]
    public int? КлассСемянИд { get; set; }

    [Обязательное]
    public int? ИдХозяйства { get; set; }

    [Обязательное]
    public int? ИдПоля { get; set; }

    [Обязательное]
    public int? ИдУчастка { get; set; }

    [Range(15, 65)]
    public int РазмерКлубня { get; set; } = 15;

    public string КоординатыУчастка { get; set; }
    [Обязательное]
    public string СевооборотПрошлогоГода { get; set; }
    [Обязательное]
    public string Севооборот2ГодаНазад { get; set; }
    [Обязательное]
    public string Севооборот3ГодаНазад { get; set; }
    [Обязательное]
    public string ИзоляцияПолей { get; set; }
    [Обязательное]
    public string СтранаПроизводитель { get; set; }
    [Обязательное]
    public string НаваниеКомпанииПроизводителя { get; set; }
    [Обязательное]
    public int ГодПроизводстваСемян { get; set; }
    //[Display(Name = "СвидетельствоПроисхождения", ResourceType = typeof(ДанныеЗаявки))]
    [Обязательное]
    public byte[] СвидетельствоПроисхожденияСемян { get; set; }
    [Обязательное]
    public string КодСертификатаПроисхождения { get; set; }
    public int? ИдСертификатаПроисхождения { get; set; }
    [Обязательное]
    public byte[] ЗаключениеОНематодах { get; set; }
    public string? Протравители { get; set; }
    public string? Инсектициды { get; set; }
    public string? Фунгициды { get; set; }
    public string? Удобрения { get; set; }
    public string? Гербициды { get; set; }
    [Обязательное]
    public int? ФормаУчастка { get; set; }
    public string? Размер1 { get; set; }
    public string? Размер2 { get; set; }
    [Обязательное]
    public string ПлощадьПосадки { get; set; }
    [Обязательное]
    public string РасстояниеМеждуРядами { get; set; } = "75";
    [Обязательное]
    public string РасстояниеВРяду { get; set; } = "20";
    public int Статус { get; set; }
    public int РекомендуемоеКоличествоРастений
    {
        get
        {
            if (double.TryParse(ПлощадьПосадки, out var площадь)
                && int.TryParse(РасстояниеМеждуРядами, out var расстояниеМеждуРядами)
                && int.TryParse(РасстояниеВРяду, out var расстояниеВРяду))
            {
                var растенийНаКвМетр = 10_000.0 / (расстояниеМеждуРядами * расстояниеВРяду);
                var растенийНаГектар = 10_000.0 * растенийНаКвМетр;
                return Math.Max((int)(площадь * растенийНаГектар), 100_000) / 100;
            }

            return 0;
        }
    }
    public string ПрогнозируемоеКоличествоУрожая { get; set; } = "";
    public DateTime ДатаПосадки { get; set; } = DateTime.UtcNow;
    public DateTime ДатаСбора { get; set; } = DateTime.UtcNow;
}
