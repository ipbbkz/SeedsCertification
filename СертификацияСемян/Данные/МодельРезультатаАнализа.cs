namespace СертификацияСемян.Данные;

public class МодельРезультатаАнализа
{
    public int КоличествоОбразцов { get; set; }
    public DateTime ДатаВзятияОбразца { get; set; }
    public DateTime ДатаПередачиВЛабораторию { get; set; }
    public int Статус { get; set; }
    public bool[] PLRV { get; set; }
    public bool[] PVA { get; set; }
    public bool[] PVM { get; set; }
    public bool[] PVX { get; set; }
    public bool[] PVY { get; set; }
    public bool[] PVS { get; set; }
    public bool[] Clavibacter { get; set; }
    public bool[] Ralstonia { get; set; }

    [Обязательное]
    public byte[]? ФайлСАнализами { get; set; }
}
