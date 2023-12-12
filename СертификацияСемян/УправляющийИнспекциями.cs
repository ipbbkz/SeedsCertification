using Microsoft.EntityFrameworkCore;
using СертификацияСемян.Данные;

namespace СертификацияСемян;

public class УправляющийИнспекциями
{
    private readonly КонтекстБдПриложения контекст;

    public УправляющийИнспекциями(КонтекстБдПриложения контекст)
    {
        this.контекст = контекст;
    }

    public IList<Инспекция> ПолучитьИнспекцииЗаявки(int идЗаявки)
    {
        return контекст.Инспекции
            .Where(_ => _.ЗаявкаИд == идЗаявки)
            .OrderByDescending(з => з.ДатаСоздания).ToList();
    }
}
