using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace СертификацияСемян.ИнтеграционныеТесты;

public class ВходТесты : IDisposable
{
    private WebDriver драйвер;

    private static string БазовыйАдрес => Environment.GetEnvironmentVariable("CERTIFICATES_IPBB_ADDRESS") ?? "http://certificates.ipbb.kz/Identity/Account/Login";

    public ВходТесты()
    {
        // Initialize edge driver
        var параметры = new ChromeOptions
        {
            PageLoadStrategy = PageLoadStrategy.Normal,
        };
        параметры.AddArguments("--start-maximized");
        this.драйвер = new ChromeDriver(параметры);
    }

    public void Dispose()
    {
        this.драйвер.Dispose();
    }

    [Fact]
    public void СтраницаВходаРаботает()
    {
        // Act
        this.драйвер.Url = $"{БазовыйАдрес}";

        // Assert
        var заголовокСтраницы = this.драйвер.FindElement(By.CssSelector("h1"));
        Assert.Equal("Log in", заголовокСтраницы.Text);

        var подписьКЛогину = this.драйвер.FindElement(By.CssSelector("[for='Input_Email']"));
        Assert.Equal("Email", подписьКЛогину.Text);

        var подписьКПаролю = this.драйвер.FindElement(By.CssSelector("[for='Input_Password']"));
        Assert.Equal("Password", подписьКПаролю.Text);

        var главнаяКнопка = this.драйвер.FindElement(By.CssSelector(".btn-primary"));
        Assert.Equal("Log in", главнаяКнопка.Text);
    }
}