﻿using Microsoft.EntityFrameworkCore;
using СертификацияСемян.Данные;

namespace СертификацияСемян;

public class УправляющийЗаявками
{
    private readonly КонтекстБдПриложения контекст;

    public УправляющийЗаявками(КонтекстБдПриложения контекст)
    {
        this.контекст = контекст;
    }

    public IList<Заявка> ПолучитьСтраницуЗаявок(int counter)
    {
        return контекст.Заявки
            .Include(_ => _.УчастокПоля)
            .ThenInclude(_ => _.Поле)
            .ThenInclude(_ => _.ПроизводительСемян)
            .OrderByDescending(з => з.ДатаСоздания).Skip(20 * counter).Take(20).ToList();
    }

    public IList<Заявка> ПолучитьЗаявкиНаСертификацию()
    {
        return контекст.Заявки
            .Include(_ => _.УчастокПоля)
            .ThenInclude(_ => _.Поле)
            .ThenInclude(_ => _.ПроизводительСемян)
            .Where(_ => _.Статус == 2)
            .OrderByDescending(з => з.ДатаСоздания).ToList();
    }

    public IList<Заявка> ПолучитьЗаявкиПользователя(string идПользователя)
    {
        return контекст.Заявки
            .Include(_ => _.УчастокПоля)
            .ThenInclude(_ => _.Поле)
            .ThenInclude(_ => _.ПроизводительСемян)
            .Where(_ => _.УчастокПоля.Поле.ПроизводительСемян.ИдВладельца == идПользователя && _.ДатаУдаления == null).ToList();
    }

    public Заявка? ПолучитьЗаявкуПользователя(string идПользователя, int идЗаявки) =>
        контекст.Заявки
        .Include(_ => _.УчастокПоля)
        .ThenInclude(_ => _.Поле)
        .ThenInclude(_ => _.ПроизводительСемян)
        .FirstOrDefault(_ => _.УчастокПоля.Поле.ПроизводительСемян.ИдВладельца == идПользователя && _.Ид == идЗаявки && _.ДатаУдаления == null);

    public Заявка? ПолучитьЗаявку(int идЗаявки) => контекст.Заявки
        .Include(_ => _.УчастокПоля)
        .ThenInclude(_ => _.Поле)
        .ThenInclude(_ => _.ПроизводительСемян)
        .FirstOrDefault(x => x.Ид == идЗаявки);
    

    public void ДобавитьЗаявку(
        int ТипЗаявки,
        int ИдУчастка,
        int КлассСемянИд,
        string НаваниеСортаСемян,
        int РазмерКлубня,
        string КоординатыУчастка,
        string СевооборотПрошлогоГода,
        string Севооборот2ГодаНазад,
        string Севооборот3ГодаНазад,
        string ИзоляцияПолей,
        byte[] СвидетельствоПроисхожденияСемян,
        byte[] ЗаключениеОНематодах,
        string Протравители,
        string Инсектициды,
        string Фунгициды,
        string Удобрения,
        string Гербициды,
        int ФормаУчастка,
        string? Размер1,
        string? Размер2,
        string ПлощадьПосадки,
        string РасстояниеМеждуРядами,
        string РасстояниеВРяду,
        string ПрогнозируемоеКоличествоУрожая,
        DateTime ДатаПосадки,
        DateTime ДатаСбора)
    {
        контекст.Заявки.Add(new Заявка()
        {
            ИдУчастка = ИдУчастка,
            ТипЗаявки = ТипЗаявки,
            КлассСемянИд = КлассСемянИд,
            НаваниеСортаСемян = НаваниеСортаСемян,
            РазмерКлубня = РазмерКлубня,
            КоординатыУчастка = КоординатыУчастка,
            СевооборотПрошлогоГода = СевооборотПрошлогоГода,
            Севооборот2ГодаНазад = Севооборот2ГодаНазад,
            Севооборот3ГодаНазад = Севооборот3ГодаНазад,
            ИзоляцияПолей = ИзоляцияПолей,
            СвидетельствоПроисхожденияСемян = СвидетельствоПроисхожденияСемян,
            ЗаключениеОНематодах = ЗаключениеОНематодах,
            Протравители = Протравители,
            Инсектициды = Инсектициды,
            Фунгициды = Фунгициды,
            Удобрения = Удобрения,
            Гербициды = Гербициды,
            ФормаУчастка = ФормаУчастка,
            Размер1 = Размер1,
            Размер2 = Размер2,
            ПлощадьПосадки = ПлощадьПосадки,
            РасстояниеМеждуРядами = РасстояниеМеждуРядами,
            РасстояниеВРяду = РасстояниеВРяду,
            ПрогнозируемоеКоличествоУрожая = ПрогнозируемоеКоличествоУрожая,
            ДатаПосадки = ДатаПосадки,
            ДатаСбора = ДатаСбора,
            Активно = true,
            Статус = 1,
        });
        контекст.SaveChanges();
    }

    public void ОтправитьНаСертификацию(int ид)
    {
        контекст.Заявки
            .Where(и => и.Ид == ид)
            .ExecuteUpdate(_ => _
                .SetProperty(и => и.Статус, 2));
    }

    public void ВыпуститьСертификат(int ид, int классСемянИд, int валовыйУрожай)
    {
        контекст.Заявки
            .Where(и => и.Ид == ид)
            .ExecuteUpdate(_ => _
                .SetProperty(и => и.Статус, 3));
        контекст.Сертификаты.Add(new Сертификат
        {
            ВаловыйПродукт = валовыйУрожай,
            КлассСемянИд = классСемянИд,
            ЗаявкаИд = ид,
            ДатаВыпуска = DateTime.UtcNow,
        });
        контекст.SaveChanges();
    }
}
