using System.ComponentModel.DataAnnotations;

namespace СертификацияСемян.Данные;

public class Хозяйство
{
    public int ФормаХозяйствования { get; set; }

    [Required]
    public string НаваниеКомпании { get; set; }

    [Required]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "Длина БИН/ИИН должна быть 12 символов.")]
    public string Бин { get; set; }

    [Required]
    public string ЮридическийАдрес { get; set; }
    [Required]
    public string КонтактноеЛицо { get; set; }
    [Required]
    public string ЭлектроннаяПочтаКонтактногоЛица { get; set; }
    [Required]
    public string НомерТелефонаКонтактногоЛица { get; set; }
}