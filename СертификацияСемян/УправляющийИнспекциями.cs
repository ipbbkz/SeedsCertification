﻿namespace СертификацияСемян;

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

    public void ЗапланироватьИнспекцию(int идЗаявки, int типИнспекции, DateTime планируемаяДата, DateTime? фактическаяДата, string физиологическаяСтадия, string имяВедущегоИнспектора)
    {
        контекст.Инспекции.Add(new Инспекция()
        {
            ЗаявкаИд = идЗаявки,
            ТипИнспекции = типИнспекции,
            ПланируемаяДата = планируемаяДата,
            ФактическаяДата = фактическаяДата,
            ФизиологическаяСтадия = физиологическаяСтадия,
            ИмяВедущегоИнспектора = имяВедущегоИнспектора,
            ДругиеИнспектора = "",
            ОбщиеУсловияПоля = "",
            Статус = 1,
        });
        контекст.SaveChanges();
    }
}
