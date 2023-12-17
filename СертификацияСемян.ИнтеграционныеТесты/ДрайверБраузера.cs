using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace СертификацияСемян.ИнтеграционныеТесты;

public class ДрайверБраузера : IDisposable
{
    private readonly Lazy<IWebDriver> _текущийВебДрайверЛенивый;
    private bool _удален;

    public ДрайверБраузера()
    {
        _текущийВебДрайверЛенивый = new Lazy<IWebDriver>(СоздатьВебВодителя);
    }

    internal IWebDriver Текущий => _текущийВебДрайверЛенивый.Value;

    private IWebDriver СоздатьВебВодителя()
    {
        //We use the Chrome browser
        var сервисВодителяХрома = ChromeDriverService.CreateDefaultService();

        var настройкиХрома = new ChromeOptions();

        var водительХрома = new ChromeDriver(сервисВодителяХрома, настройкиХрома);

        return водительХрома;
    }

    /// <summary>
    /// Disposes the Selenium web driver (closing the browser) after the Scenario completed
    /// </summary>
    public void Dispose()
    {
        if (_удален)
        {
            return;
        }

        if (_текущийВебДрайверЛенивый.IsValueCreated)
        {
            Текущий.Quit();
        }

        _удален = true;
    }
}
