namespace СертификацияСемян.Данные;

public class МодельСертификатаПроисхождения
{
    public required string Код { get; set; }
    public required string НазваниеКомпании { get; set; }
    public required string СтранаПроизводитель { get; set; }
    public required int ГодВыпуска { get; set; }
}
