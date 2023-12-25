namespace СертификацияСемян.Данные;

using System.ComponentModel.DataAnnotations;

public class МодельИнспекции
{
    [Обязательное]
    public int? ТипИнспекции { get; set; }

    [Обязательное]
    public DateTime? ПланируемаяДата { get; set; }

    public DateTime? ФактическаяДата { get; set; }
    [ОбязательноЕслиЛюбой(nameof(ТипИнспекции), new[] { 1, 2 })]
    public string ФизиологическаяСтадия { get; set; }
    public string? ОбщееСостояниеПоля { get; set; }
    [Обязательное]
    public string ИмяВедущегоИнспектора { get; set; }
    public string? ИмяВторогоИнспектора { get; set; }
    public int Статус { get; set; }
}
