
using Microsoft.AspNetCore.Identity;
using СертификацияСемян.Данные;

namespace СертификацияСемян;

public class ИнициализацияБазыДанных : BackgroundService
{
    private readonly IServiceScopeFactory фабрикаОбластиСервисов;

    public ИнициализацияБазыДанных(IServiceScopeFactory фабрикаОбластиСервисов) => this.фабрикаОбластиСервисов = фабрикаОбластиСервисов;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var область = фабрикаОбластиСервисов.CreateScope();
        var менеджерПользователей = область.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var администраторы = await менеджерПользователей.GetUsersInRoleAsync(Константы.РольАдминистратора);
        if (администраторы.Count == 0)
        {
            const string ПользовательАдминистратора = "admin@admin";
            const string НачальныйПарольАдминистратора = "Admin#3";
            var администратор = new IdentityUser()
            {
                Email = ПользовательАдминистратора,
                UserName = ПользовательАдминистратора,
            };
            var результат = await менеджерПользователей.CreateAsync(администратор, НачальныйПарольАдминистратора);
            if (!результат.Succeeded)
            {
                if (!результат.Errors.Any(_ => _.Code == "DuplicateUserName"))
                {
                    return;
                }

                администратор = await менеджерПользователей.FindByNameAsync(ПользовательАдминистратора);
                if (администратор is null)
                {
                    throw new InvalidOperationException("База данных в некорректном состоянии. Проверьте наличие логина администратора");
                }
            }

            var кодПодтверждения = await менеджерПользователей.GenerateEmailConfirmationTokenAsync(администратор);
            результат = await менеджерПользователей.ConfirmEmailAsync(администратор, кодПодтверждения);
            if (!результат.Succeeded) return;

            результат = await менеджерПользователей.AddToRoleAsync(администратор, Константы.РольАдминистратора);
            if (!результат.Succeeded) return;
        }
    }
}
