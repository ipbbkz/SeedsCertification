using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using СертификацияСемян;
using СертификацияСемян.Areas.Identity;
using СертификацияСемян.Данные;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<КонтекстБдПриложения>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ПользовательПриложения>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<КонтекстБдПриложения>();
builder.Services.AddRazorPages();
//builder.Services.AddRazorPages(настройки => настройки.RootDirectory = "/Страницы");
builder.Services.AddControllers();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ПользовательПриложения>>();
builder.Services.AddScoped<УправляющийХозяйствами>();
builder.Services.AddScoped<УправляющийЗаявками>();
builder.Services.AddScoped<УправляющийИнспекциями>();
builder.Services.AddLocalization();
builder.Services.AddMvc()
     .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
     .AddDataAnnotationsLocalization();
builder.Services.AddHostedService<ИнициализацияБазыДанных>();
builder.Services.AddTransient<IEmailSender, Почтальон>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ТребуетсяБытьАдминистратором",
         policy => policy.RequireRole(Константы.РольАдминистратора));
    options.AddPolicy("ТребуетсяБытьСуперАдминистратором",
         policy => policy.RequireRole(Константы.РольАдминистратора)/*.RequireClaim("NonExistingClaim")*/);
    options.AddPolicy("Фермеры",
         policy => policy.RequireRole(Константы.РольФермер));
    options.AddPolicy("Инспекторы",
         policy => policy.RequireRole(Константы.РольИнспектора));
    options.AddPolicy("Лаборатории",
         policy => policy.RequireRole(Константы.РольЛаборатория));
    options.AddPolicy("Сертификатор",
         policy => policy.RequireRole(Константы.РольСтаршийИнспектор));
});

var app = builder.Build();

var supportedCultures = new[] { "kk", "ru", "en-US" };
app.UseRequestLocalization(new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
