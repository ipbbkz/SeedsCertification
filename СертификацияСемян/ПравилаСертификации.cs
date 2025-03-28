﻿using СертификацияСемян.Данные;

namespace СертификацияСемян;

public class ПравилаСертификации
{
    public static class ПравилаИнспекцииПартии
    {
        public static double[] СухаяГниль           = new[] { 0.0, 0.2, 1.0, 1.0, 1.0, 1.0, 1.0, };
        public static double[] МокраяГниль          = new[] { 0.0, 0.2, 1.0, 1.0, 1.0, 1.0, 1.0, };
        public static double[] Фитофтороз           = new[] { 0.0, 0.2, 1.0, 1.0, 1.0, 1.0, 1.0, };
        public static double[] ПаршаОбыкновенная    = new[] { 0.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, };
        public static double[] ПаршаЛуговая         = new[] { 0.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, };
        public static double[] ПаршаСеребристая     = new[] { 0.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, };
        public static double[] ПаршаПорошистая      = new[] { 0.0, 1.0, 3.0, 3.0, 3.0, 3.0, 3.0, };
        public static double[] Ризоктониоз          = new[] { 0.0, 1.0, 5.0, 5.0, 5.0, 5.0, 5.0, };
        public static double[] Продавленность       = new[] { 3.0, 3.0, 3.0, 3.0, 3.0, 3.0, 3.0, };
        public static double[] ВнешниеДефекты       = new[] { 3.0, 3.0, 3.0, 3.0, 3.0, 3.0, 3.0, };
        public static double[] ПрилипшаяПочва       = new[] { 1.0, 1.0, 2.0, 2.0, 2.0, 2.0, 2.0, };
        public static double[] ПревышениеРазмеров   = new[] { 3.0, 3.0, 3.0, 3.0, 3.0, 3.0, 3.0, };
        public static double[] РаздавленныеКлубни   = new[] { 0.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, };
        public static double[] Переохлаждение       = new[] { 0.0, 2.0, 2.0, 2.0, 2.0, 2.0, 2.0, };
        public static double[] Вредители            = new[] { 0.0, 4.0, 4.0, 4.0, 4.0, 4.0, 4.0, };
        public static double[] ВесДефектов          = new[] { 3.0, 5.0, 6.0, 6.0, 6.0, 6.5, 7.0, };
    }
    public static class ПравилаПолевойИнспекции
    {
        public static double[] ВиральныеБолезни = new[] { 0.0, 0.1,  0.2,  0.5,  0.8,  2.0, 6.0 };
        public static double[] Черноножка       = new[] { 0.0, 0.5,  0.5,  0.75, 1.0,  1.5, 2.0 };
        public static double[] Безтиповые       = new[] { 0.0, 0.01, 0.25, 0.25, 0.25, 0.5, 0.5 };
    }

    public static КлассСемян РекомендованныйКлассСемян(ЗаписьИнспекцииПартии инспекцияПартии, КлассСемян запрашиваемыйКлассСемян)
    {
        var расчитанныйКласс = РекомендованныйКлассСемян(инспекцияПартии);
        return МинимальныйКлассСемян(расчитанныйКласс, запрашиваемыйКлассСемян);
    }

    private static КлассСемян РекомендованныйКлассСемян(ЗаписьИнспекцииПартии инспекцияПартии)
    {
        var классы = new[]
        {
            Порог(инспекцияПартии.СухаяГниль,                ПравилаИнспекцииПартии.СухаяГниль),
            Порог(инспекцияПартии.МокраяГниль,               ПравилаИнспекцииПартии.МокраяГниль),
            Порог(инспекцияПартии.Фитофтороз,                ПравилаИнспекцииПартии.Фитофтороз),
            Порог(инспекцияПартии.ПаршаОбыкновенная,         ПравилаИнспекцииПартии.ПаршаОбыкновенная),
            Порог(инспекцияПартии.ПаршаЛуговая,              ПравилаИнспекцииПартии.ПаршаЛуговая),
            Порог(инспекцияПартии.ПаршаСеребристая,          ПравилаИнспекцииПартии.ПаршаСеребристая),
            Порог(инспекцияПартии.ПаршаПорошистая,           ПравилаИнспекцииПартии.ПаршаПорошистая),
            Порог(инспекцияПартии.Ризоктониоз,               ПравилаИнспекцииПартии.Ризоктониоз),
            Порог(инспекцияПартии.Продавленность,            ПравилаИнспекцииПартии.Продавленность),
            //Порог(инспекцияПартии.НезначительныеПовреждения, new []{ 0.0, 0.2, 1.0, 1.0, }),
            Порог(инспекцияПартии.ВнешниеДефекты,            ПравилаИнспекцииПартии.ВнешниеДефекты),
            Порог(инспекцияПартии.ПрилипшаяПочва,            ПравилаИнспекцииПартии.ПрилипшаяПочва),
            Порог(инспекцияПартии.ПревышениеРазмеров,        ПравилаИнспекцииПартии.ПревышениеРазмеров),
            //Порог(инспекцияПартии.Проростания,               new []{ 0.0, 0.2, 1.0, 1.0, }),
            //Порог(инспекцияПартии.ВнутренниеДефекты,         new []{ 0.0, 0.2, 1.0, 1.0, }),
            Порог(инспекцияПартии.РаздавленныеКлубни,        ПравилаИнспекцииПартии.РаздавленныеКлубни),
            //Порог(инспекцияПартии.ВирусныйНекроз,            new []{ 0.0, 0.2, 1.0, 1.0, }),
            Порог(инспекцияПартии.Переохлаждение,            ПравилаИнспекцииПартии.Переохлаждение),
            Порог(инспекцияПартии.Вредители,                 ПравилаИнспекцииПартии.Вредители),

            Порог(инспекцияПартии.ВесДефектов,                 ПравилаИнспекцииПартии.ВесДефектов),
        };

        return МинимальныйКлассСемян(классы);

        КлассСемян Порог(double? значение, double[] уровни) => ПорогИнспекцииПартии(значение, инспекцияПартии.ИнспектируемыйВес, уровни);
    }

    public static КлассСемян ПорогИнспекцииПартии(double? значение, int вес, double[] уровни)
    {
        var процент = 100.0 * (значение ?? 0) / вес;
        if (процент <= уровни[0])
        {
            return КлассСемян.ПредбазисныйPBTC;
        }

        if (процент <= уровни[1])
        {
            return КлассСемян.ПредбазисныйPB;
        }

        if (процент <= уровни[2])
        {
            return КлассСемян.БазисныйS;
        }

        if (процент <= уровни[3])
        {
            return КлассСемян.БазисныйSE;
        }

        if (процент <= уровни[4])
        {
            return КлассСемян.БазисныйE;
        }

        if (процент <= уровни[5])
        {
            return КлассСемян.СертифицированныйА;
        }

        if (процент <= уровни[6])
        {
            return КлассСемян.СертифицированныйВ;
        }

        return КлассСемян.Неизвестный;
    }

    public static КлассСемян РекомендованныйКлассСемян(List<ЗаписьПолевойИнспекции> полевыеИнспекции, КлассСемян запрашиваемыйКлассСемян)
    {
        var расчитанныйКласс = РекомендованныйКлассСемян(полевыеИнспекции);
        return МинимальныйКлассСемян(расчитанныйКласс, запрашиваемыйКлассСемян);
    }

    public static КлассСемян РекомендованныйКлассСемян(List<ЗаписьПолевойИнспекции> полевыеИнспекции)
    {
        var объединенныеРезультаты = new ЗаписьПолевойИнспекции()
        {
            КоличествоРастенийВСерии = полевыеИнспекции.Sum(_ => _.КоличествоРастенийВСерии),
            ВиральныеБолезни = полевыеИнспекции.Sum(_ => _.ВиральныеБолезни),
            Черноножка = полевыеИнспекции.Sum(_ => _.Черноножка),
            Безтиповые = полевыеИнспекции.Sum(_ => _.Безтиповые),
        };
        var классы = new[]
        {
            Порог(объединенныеРезультаты.ВиральныеБолезни,  ПравилаПолевойИнспекции.ВиральныеБолезни),
            Порог(объединенныеРезультаты.Черноножка,        ПравилаПолевойИнспекции.Черноножка),
            Порог(объединенныеРезультаты.Безтиповые,        ПравилаПолевойИнспекции.Безтиповые),
        };

        return МинимальныйКлассСемян(классы);

        КлассСемян Порог(int? значение, double[] уровни) => ПорогПолевойИнспекции(значение, объединенныеРезультаты.КоличествоРастенийВСерии, уровни);
    }
    public static КлассСемян ПорогПолевойИнспекции(int? значение, int количествоРастенийВСерии, double[] уровни)
    {
        var процент = 100.0 * (значение ?? 0) / количествоРастенийВСерии;
        if (процент <= уровни[0])
        {
            return КлассСемян.ПредбазисныйPBTC;
        }

        if (процент <= уровни[1])
        {
            return КлассСемян.ПредбазисныйPB;
        }

        if (процент <= уровни[2])
        {
            return КлассСемян.БазисныйS;
        }

        if (процент <= уровни[3])
        {
            return КлассСемян.БазисныйSE;
        }

        if (процент <= уровни[4])
        {
            return КлассСемян.БазисныйE;
        }

        if (процент <= уровни[5])
        {
            return КлассСемян.СертифицированныйА;
        }

        if (процент <= уровни[6])
        {
            return КлассСемян.СертифицированныйВ;
        }

        return КлассСемян.Неизвестный;
    }

    public static КлассСемян МинимальныйКлассСемян(IEnumerable<КлассСемян> классы)
        => классы.Aggregate(КлассСемян.ПредбазисныйPBTC, МинимальныйКлассСемян);

    public static КлассСемян МинимальныйКлассСемян(КлассСемян класс1, КлассСемян класс2)
    {
        var классы = new[]
        {
            КлассСемян.Неизвестный,
            КлассСемян.СертифицированныйВ,
            КлассСемян.СертифицированныйА,
            КлассСемян.БазисныйE,
            КлассСемян.БазисныйSE,
            КлассСемян.БазисныйS,
            КлассСемян.ПредбазисныйPB,
            КлассСемян.ПредбазисныйPBTC,
        };
        foreach (var целевой in классы)
        {
            if (класс1 == целевой || класс2 == целевой)
            {
                return целевой;
            }
        }

        return КлассСемян.Неизвестный;
    }
}
