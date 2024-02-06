using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using СертификацияСемян;
using СертификацияСемян.Areas.Identity;
using СертификацияСемян.Данные;

var построитель = ВебПриложение.СоздатьПостроителя(args);

// Добавить сервисы в контейнер.
var строкаПодключения = построитель.Конфигурация.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
построитель.Сервиси.AddDbContext<КонтекстБдПриложения>(options =>
    options.UseSqlServer(строкаПодключения));
построитель.Сервиси.AddDatabaseDeveloperPageExceptionFilter();
построитель.Сервиси.AddDefaultIdentity<ПользовательПриложения>(настройки => настройки.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<КонтекстБдПриложения>();
построитель.Сервиси.AddRazorPages(настройки => настройки.RootDirectory = "/Страницы");
построитель.Сервиси.AddControllers();
построитель.Сервиси.AddServerSideBlazor();
построитель.Сервиси.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ПользовательПриложения>>();
построитель.Сервиси.AddScoped<УправляющийХозяйствами>();
построитель.Сервиси.AddScoped<УправляющийЗаявками>();
построитель.Сервиси.AddScoped<УправляющийИнспекциями>();
построитель.Сервиси.AddLocalization();
построитель.Сервиси.AddMvc()
     .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
     .AddDataAnnotationsLocalization();
построитель.Сервиси.AddHostedService<ИнициализацияБазыДанных>();
построитель.Сервиси.AddTransient<IEmailSender, Почтальон>();
построитель.Сервиси.AddAuthorization(опции =>
{
    опции.AddPolicy("ТребуетсяБытьАдминистратором",
         policy => policy.RequireRole(Константы.РольАдминистратора));
    опции.AddPolicy("ТребуетсяБытьСуперАдминистратором",
         policy => policy.RequireRole(Константы.РольАдминистратора)/*.RequireClaim("NonExistingClaim")*/);
    опции.AddPolicy("Фермеры",
         policy => policy.RequireRole(Константы.РольФермер));
    опции.AddPolicy("Инспекторы",
         policy => policy.RequireRole(Константы.РольИнспектора));
    опции.AddPolicy("ИнспекторыИлиФермеры",
         policy => policy.RequireRole(Константы.РольИнспектора, Константы.РольФермер));
    опции.AddPolicy("Лаборатории",
         policy => policy.RequireRole(Константы.РольЛаборатория));
    опции.AddPolicy("Сертификатор",
         policy => policy.RequireRole(Константы.РольСтаршийИнспектор));
});

var app = построитель.Построить();

var supportedCultures = new[] { "kk", "ru", "en-US" };
app.UseRequestLocalization(new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures));

// Настроить трубопровод HTTP запросов.
if (app.Окружение.ВРазработке())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.ИспользоватьОбработчикОшибок("/Error");
    // Значение HSTS по умолчанию 30 дней. Вы можете изменить это значения для промышленный сценариев, смотри https://aka.ms/aspnetcore-hsts.
    app.ИспользоватьHsts();
}

app.ИспользоватьПеренаправлениеHttps();

app.ИспользоватьСтатическиеФайлы();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Запустить();
