using System.ComponentModel.DataAnnotations;

namespace СертификацияСемян.Данные;

public class МодельПоля
{
    public int Ид { get; set; }
    public int ИдХозяйства { get; set; }

    [Обязательное]
    public string Название { get; set; }

    [Обязательное]
    public string АдресПоля { get; set; }

    [Обязательное]
    public byte[] ПравоустанавливающиеДокументы { get; set; }

    public bool Активно { get; set; }
}
