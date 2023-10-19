using System.ComponentModel.DataAnnotations;

namespace СертификацияСемян.Данные;

public class МодельПоля
{
    public int Ид { get; set; }
    public int ИдХозяйства { get; set; }

    [Required]
    public string Название { get; set; }

    [Required]
    public string АдресПоля { get; set; }

    [Required]
    public byte[] ПравоустанавливающиеДокументы { get; set; }

    public bool Активно { get; set; }
}
