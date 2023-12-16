using System.ComponentModel.DataAnnotations;

namespace СертификацияСемян.Данные;

public class МодельПользователя
{
    [Обязательное]
    [EmailAddress]
    public string Почта { get; set; } = "";

    [Обязательное]
    public string Фамилия { get; set; } = "";

    [Обязательное]
    public string Имя { get; set; } = "";

    public string? Отчество { get; set; }
}
