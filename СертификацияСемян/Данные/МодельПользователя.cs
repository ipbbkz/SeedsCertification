using System.ComponentModel.DataAnnotations;

namespace СертификацияСемян.Данные;

public class МодельПользователя
{
    [Required]
    [EmailAddress]
    public string Почта { get; set; } = "";

    [Required]
    public string Фамилия { get; set; } = "";

    [Required]
    public string Имя { get; set; } = "";

    public string? Отчество { get; set; }
}
