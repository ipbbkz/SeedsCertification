namespace СертификацияСемян.ИнтеграционныеТесты.Шаги;

using OpenQA.Selenium;
using TechTalk.SpecFlow;

[Binding]
public sealed class ОписаниеШаговСтраниц
{
    private readonly ДрайверБраузера водитель;

    public ОписаниеШаговСтраниц(ДрайверБраузера водитель)
    {
        this.водитель = водитель;
    }

    [Given("пользователь перешел на страницу входа")]
    public void ОткрытьСтрницуВхода()
    {
        водитель.Текущий.Url = "http://certificates.ipbb.kz/Identity/Account/Login";
    }

    [Then("заголовок страницы равен \"(.*)\"")]
    public void ОткрытьСтрницуВхода(string ожидаемыйЗаголовок)
    {
        Assert.Equal(ожидаемыйЗаголовок, водитель.Текущий.Title);
    }
}
