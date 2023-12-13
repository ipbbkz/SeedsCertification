namespace СертификацияСемян.Данные;

using System.ComponentModel.DataAnnotations;

public class МодельИнспекции
{
    [Required]
    public int? ТипИнспекции { get; set; }

    [Required]
    public DateTime? ПланируемаяДата { get; set; }

    public DateTime? ФактическаяДата { get; set; }
    public string ФизиологическаяСтадия { get; set; }
    public string ИмяВедущегоИнспектора { get; set; }
    public int Статус { get; set; }
}
