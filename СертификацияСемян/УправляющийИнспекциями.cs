﻿namespace СертификацияСемян;

using Microsoft.EntityFrameworkCore;
using СертификацияСемян.Данные;

public class УправляющийИнспекциями
{
    private readonly КонтекстБдПриложения контекст;

    public УправляющийИнспекциями(КонтекстБдПриложения контекст)
    {
        this.контекст = контекст;
    }

    public IList<Инспекция> ПолучитьИнспекцииЗаявки(int идЗаявки)
    {
        return контекст.Инспекции
            .Where(_ => _.ЗаявкаИд == идЗаявки)
            .OrderByDescending(з => з.ДатаСоздания).ToList();
    }

    public void ЗапланироватьИнспекцию(int идЗаявки, int типИнспекции, DateTime планируемаяДата, DateTime? фактическаяДата, string физиологическаяСтадия, string? общиеУсловнияПоля, string имяВедущегоИнспектора, string? имяВторогоИнспектора)
    {
        контекст.Инспекции.Add(new Инспекция()
        {
            ЗаявкаИд = идЗаявки,
            ТипИнспекции = типИнспекции,
            ПланируемаяДата = планируемаяДата,
            ФактическаяДата = фактическаяДата,
            ФизиологическаяСтадия = физиологическаяСтадия,
            ИмяВедущегоИнспектора = имяВедущегоИнспектора,
            ДругиеИнспектора = имяВторогоИнспектора ?? "",
            ОбщиеУсловияПоля = общиеУсловнияПоля ?? "",
            Статус = 1,
        });
        контекст.SaveChanges();
    }

    public Инспекция? ПолучитьИнспекцию(int идИнспекции)
    {
        return контекст.Инспекции
            .FirstOrDefault(_ => _.Ид == идИнспекции);
    }

    public List<ЗаписьПолевойИнспекции> ПолучитьПротоколПолевойИнспекции(int идИнспекции)
    {
        return контекст.ЗаписиПолевыхИнспекций
            .Where(зи => зи.ИнспекцияИд == идИнспекции)
            .ToList();
    }

    public void СохранитьПротоколПолевойИнспекции(int идИнспекции, List<ЗаписьПолевойИнспекции> записи)
    {
        var существующиеЗаписи = ПолучитьПротоколПолевойИнспекции(идИнспекции);
        foreach (var существующаяЗапись in существующиеЗаписи)
        {
            var з = записи.FirstOrDefault(з => з.НомерСерии == существующаяЗапись.НомерСерии);
            if (з is not null)
            {
                существующаяЗапись.КоличествоРастенийВСерии = з.КоличествоРастенийВСерии;
                существующаяЗапись.Карантин = з.Карантин;
                существующаяЗапись.ВиральныеБолезни = з.ВиральныеБолезни;
                существующаяЗапись.Черноножка = з.Черноножка;
                существующаяЗапись.Безтиповые = з.Безтиповые;
                существующаяЗапись.Ризоктония = з.Ризоктония;
            }
        }

        foreach (var запись in записи)
        {
            var сз = существующиеЗаписи.FirstOrDefault(з => з.НомерСерии == запись.НомерСерии);
            if (сз is null)
            {
                запись.ИнспекцияИд = идИнспекции;
                контекст.ЗаписиПолевыхИнспекций.Add(запись);
            }
        }

        контекст.SaveChanges();
    }

    public ЗаписьИнспекцииПартии ПолучитьПротоколИнспекцииПартии(int идИнспекции)
    {
        return контекст.ЗаписиИнспекцийПартии
            .FirstOrDefault(зи => зи.ИнспекцияИд == идИнспекции) ?? new();
    }

    public void СохранитьПротоколИнспекцииПартии(int идИнспекции, ЗаписьИнспекцииПартии запись)
    {
        var существующаяЗапись = контекст.ЗаписиИнспекцийПартии
            .FirstOrDefault(зи => зи.ИнспекцияИд == идИнспекции);
        var надоДобавить = существующаяЗапись is null;
        существующаяЗапись ??= new() { ИнспекцияИд = идИнспекции };
        существующаяЗапись.ВесПартии = запись.ВесПартии;
        существующаяЗапись.СухаяГниль = запись.СухаяГниль;
        существующаяЗапись.МокраяГниль = запись.МокраяГниль;
        существующаяЗапись.Фитофтороз = запись.Фитофтороз;
        существующаяЗапись.ПаршаОбыкновенная = запись.ПаршаОбыкновенная;
        существующаяЗапись.ПаршаЛуговая = запись.ПаршаЛуговая;
        существующаяЗапись.ПаршаСеребристая = запись.ПаршаСеребристая;
        существующаяЗапись.ПаршаПорошистая = запись.ПаршаПорошистая;
        существующаяЗапись.Продавленность = запись.Продавленность;
        существующаяЗапись.НезначительныеПовреждения = запись.НезначительныеПовреждения;
        существующаяЗапись.ВнешниеДефекты = запись.ВнешниеДефекты;
        существующаяЗапись.ПрилипшаяПочва = запись.ПрилипшаяПочва;
        существующаяЗапись.ПревышениеРазмеров = запись.ПревышениеРазмеров;
        существующаяЗапись.Проростания = запись.Проростания;
        существующаяЗапись.ВнутренниеДефекты = запись.ВнутренниеДефекты;
        существующаяЗапись.РаздавленныеКлубни = запись.РаздавленныеКлубни;
        существующаяЗапись.ВирусныйНекроз = запись.ВирусныйНекроз;
        существующаяЗапись.Переохлаждение = запись.Переохлаждение;
        существующаяЗапись.Вредители = запись.Вредители;
        if (надоДобавить)
        {
            контекст.Add(существующаяЗапись);
        }

        контекст.SaveChanges();
    }

    public void ПровестиИнспекцию(int идИнспекции, DateTime фактическаяДата)
    {
        контекст.Инспекции
            .Where(и => и.Ид == идИнспекции)
            .ExecuteUpdate(_ => _
                .SetProperty(и => и.Статус, 2)
                .SetProperty(и => и.ФактическаяДата, фактическаяДата)
                .SetProperty(и => и.ДатаОбновления, DateTime.UtcNow));
    }

    public void ОдобритьИнспекцию(int идИнспекции)
    {
        контекст.Инспекции
            .Where(и => и.Ид == идИнспекции)
            .ExecuteUpdate(_ => _.SetProperty(и => и.Статус, 3));
    }

    public void ОтклонитьИнспекцию(int идИнспекции)
    {
        контекст.Инспекции
            .Where(и => и.Ид == идИнспекции)
            .ExecuteUpdate(_ => _.SetProperty(и => и.Статус, 4));
    }

    public List<Анализ> ПолучитьАнализы(int идИнспекции)
    {
        return контекст.Анализы.Where(_ => _.ИнспекцияИд == идИнспекции).ToList();
    }

    public List<Анализ> ПолучитьОжидающиеАнализы()
    {
        return контекст.Анализы
            .Include(а => а.Инспекция)
            .ThenInclude(и => и.Заявка)
            .Where(_ => _.Статус == 1).ToList();
    }

    public void ОтправитьАнализы(int идИнспекции, List<Анализ> анализы)
    {
        foreach (var анализ in анализы)
        {
            анализ.ИнспекцияИд = идИнспекции;
            контекст.Анализы.Add(анализ);
        }

        контекст.SaveChanges();

        контекст.Инспекции
            .Where(и => и.Ид == идИнспекции)
            .ExecuteUpdate(_ => _.SetProperty(и => и.Статус, 5));
    }
}
