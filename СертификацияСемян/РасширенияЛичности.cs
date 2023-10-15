using System.Security.Claims;
using System.Security.Principal;

namespace СертификацияСемян;

public static class РасширенияЛичности
{
    public static string? ПолучитьИдентификаторБезопасности(this ClaimsIdentity личность)
    {
        var идЛичности = личность.FindFirst(ClaimTypes.Sid)?.Value;
        return идЛичности;
    }
}
