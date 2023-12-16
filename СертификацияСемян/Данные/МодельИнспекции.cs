namespace СертификацияСемян.Данные;

using System.ComponentModel.DataAnnotations;

public class МодельИнспекции
{
    [Обязательное]
    public int? ТипИнспекции { get; set; }

    [Обязательное]
    public DateTime? ПланируемаяДата { get; set; }

    public DateTime? ФактическаяДата { get; set; }
    public string ФизиологическаяСтадия { get; set; }
    public string ИмяВедущегоИнспектора { get; set; }
    public int Статус { get; set; }
}
