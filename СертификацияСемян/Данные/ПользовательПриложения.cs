using Microsoft.AspNetCore.Identity;

namespace СертификацияСемян.Данные;

public class ПользовательПриложения : IdentityUser
{
    public string? Фамилия { get; set; }
    public string? Имя { get; set; }
    public string? Отчество { get; set; }
}
