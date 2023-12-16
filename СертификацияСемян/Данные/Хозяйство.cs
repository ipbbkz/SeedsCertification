using System.ComponentModel.DataAnnotations;

namespace СертификацияСемян.Данные;

public class Хозяйство
{
    public int ФормаХозяйствования { get; set; }

    [Обязательное]
    public string НаваниеКомпании { get; set; }

    [Обязательное]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "Длина БИН/ИИН должна быть 12 символов.")]
    public string Бин { get; set; }

    [Обязательное]
    public string ЮридическийАдрес { get; set; }
    [Обязательное]
    public string КонтактноеЛицо { get; set; }
    [Обязательное]
    public string ЭлектроннаяПочтаКонтактногоЛица { get; set; }
    [Обязательное]
    public string НомерТелефонаКонтактногоЛица { get; set; }
}