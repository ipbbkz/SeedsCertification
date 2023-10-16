using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace СертификацияСемян;

public static class РасширенияЛичности
{
    public static string? ПолучитьИдентификаторБезопасности(this ClaimsIdentity личность)
    {
        var идЛичности = личность.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return идЛичности;
    }

    public static async Task<string?> ПолучитьИдентификаторБезопасности(this Task<AuthenticationState>? состояниеАвторизации)
    {
        if (состояниеАвторизации is not null)
        {
            var authState = await состояниеАвторизации;
            var user = authState?.User;

            if (user?.Identity is ClaimsIdentity личность && личность.IsAuthenticated)
            {
                return личность.ПолучитьИдентификаторБезопасности();
            }
        }

        return null;
    }
}
