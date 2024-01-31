namespace СертификацияСемян.Данные;

public class МодельСертификата
{
    public required int Ид { get; set; }
    public required string Код { get; set; }
    public required int ТипСертификата { get; set; }
    public required string БинИин { get; set; }
    public required string НазваниеКомпании { get; set; }
}
