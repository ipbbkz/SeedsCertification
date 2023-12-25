﻿namespace СертификацияСемян.Данные;

public class МодельРезультатаАнализа
{
    public int КоличествоОбразцов { get; set; }
    public DateTime ДатаВзятияОбразца { get; set; }
    public DateTime ДатаПередачиВЛабораторию { get; set; }

    [Обязательное]
    public byte[] ФайлСАнализами { get; set; }
}
