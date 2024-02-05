﻿using СертификацияСемян.Данные;

namespace СертификацияСемян;

public static class Проектор
{
    public static void ОтобразитьЗаявку(Заявка заявка, МодельЗаявки модельЗаявки)
    {
        модельЗаявки.Ид = заявка.Ид;
        модельЗаявки.Код = заявка.Код;
        модельЗаявки.ТипЗаявки = заявка.ТипЗаявки;
        модельЗаявки.НазваниеСортаСемян = заявка.НаваниеСортаСемян;
        модельЗаявки.КлассСемянИд = заявка.КлассСемянИд;

        модельЗаявки.ИдХозяйства = заявка.УчастокПоля.Поле.ИдХозяйства;
        модельЗаявки.ИдПоля = заявка.УчастокПоля.ИдПоля;
        модельЗаявки.ИдУчастка = заявка.ИдУчастка;

        модельЗаявки.РазмерКлубня = заявка.РазмерКлубня;
        модельЗаявки.КоординатыУчастка = заявка.КоординатыУчастка;
        модельЗаявки.СевооборотПрошлогоГода = заявка.СевооборотПрошлогоГода;
        модельЗаявки.Севооборот2ГодаНазад = заявка.Севооборот2ГодаНазад;
        модельЗаявки.Севооборот3ГодаНазад = заявка.Севооборот3ГодаНазад;
        модельЗаявки.ИзоляцияПолей = заявка.ИзоляцияПолей;
        модельЗаявки.СтранаПроизводитель = заявка.СтранаПроизводитель;
        модельЗаявки.НаваниеКомпанииПроизводителя = заявка.НаваниеКомпанииПроизводителя;
        модельЗаявки.КодСертификатаПроисхождения = заявка.КодСертификатаПроисхождения;
        модельЗаявки.ИдСертификатаПроисхождения = заявка.ИдСертификатаПроисхождения;
        модельЗаявки.СвидетельствоПроисхожденияСемян = заявка.СвидетельствоПроисхожденияСемян;
        модельЗаявки.ЗаключениеОНематодах = заявка.ЗаключениеОНематодах;

        модельЗаявки.Протравители = заявка.Протравители;
        модельЗаявки.Инсектициды = заявка.Инсектициды;
        модельЗаявки.Фунгициды = заявка.Фунгициды;
        модельЗаявки.Удобрения = заявка.Удобрения;
        модельЗаявки.Гербициды = заявка.Гербициды;

        модельЗаявки.ФормаУчастка = заявка.ФормаУчастка;
        модельЗаявки.Размер1 = заявка.Размер1;
        модельЗаявки.Размер2 = заявка.Размер2;
        модельЗаявки.ПлощадьПосадки = заявка.ПлощадьПосадки;
        модельЗаявки.РасстояниеМеждуРядами = заявка.РасстояниеМеждуРядами;
        модельЗаявки.РасстояниеВРяду = заявка.РасстояниеВРяду;

        модельЗаявки.ПрогнозируемоеКоличествоУрожая = заявка.ПрогнозируемоеКоличествоУрожая;
        модельЗаявки.ДатаПосадки = заявка.ДатаПосадки;
        модельЗаявки.ДатаСбора = заявка.ДатаСбора;
        модельЗаявки.Статус = заявка.Статус;
    }

    public static void ОтобразитьИнспекцию(Инспекция инспекция, МодельИнспекции модельИнспекции)
    {
        модельИнспекции.ТипИнспекции = инспекция.ТипИнспекции;
        модельИнспекции.ПланируемаяДата = инспекция.ПланируемаяДата;
        модельИнспекции.ФактическаяДата = инспекция.ФактическаяДата;
        модельИнспекции.ФизиологическаяСтадия = инспекция.ФизиологическаяСтадия;
        модельИнспекции.ОбщееСостояниеПоля = инспекция.ОбщиеУсловияПоля;
        модельИнспекции.ИмяВедущегоИнспектора = инспекция.ИмяВедущегоИнспектора;
        модельИнспекции.ИмяВторогоИнспектора = инспекция.ДругиеИнспектора;
        модельИнспекции.Статус = инспекция.Статус;
    }

    public static void ОтобразитьАнализ(Анализ анализ, МодельРезультатаАнализа модельАнализа)
    {
        модельАнализа.КоличествоОбразцов = анализ.КоличествоОбразцов;
        модельАнализа.ДатаВзятияОбразца = анализ.ДатаВзятияОбразца;
        модельАнализа.ДатаПередачиВЛабораторию = анализ.ДатаПередачиВЛабораторию;
        модельАнализа.ФайлСАнализами = анализ.ФайлСАнализами;
        модельАнализа.Статус = анализ.Статус;
        модельАнализа.PLRV = GetFlags(анализ.PLRV, 4);
        модельАнализа.PVA = GetFlags(анализ.PVA, 4);
        модельАнализа.PVM = GetFlags(анализ.PVM, 4);
        модельАнализа.PVX = GetFlags(анализ.PVX, 4);
        модельАнализа.PVY = GetFlags(анализ.PVY, 4);
        модельАнализа.PVS = GetFlags(анализ.PVS, 4);
        модельАнализа.Clavibacter = GetFlags(анализ.Clavibacter, 2);
        модельАнализа.Ralstonia = GetFlags(анализ.Ralstonia, 2);
    }

    static bool[] GetFlags(int? value, int count)
    {
        var data = value ?? 0;
        List<bool> result = new(count);
        for (int i = 0; i < count; i++)
        {
            result.Add((data >> i) % 2 == 1);
        }

        return result.ToArray();
    }
}
