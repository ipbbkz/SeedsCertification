using System.ComponentModel.DataAnnotations;

namespace СертификацияСемян;

public class ОбязательноеAttribute : RequiredAttribute
{
    public ОбязательноеAttribute()
        : base()
    {
        ErrorMessageResourceType = typeof(Глобальные);
        ErrorMessageResourceName = nameof(Глобальные.ОбязательноеПоле);
    }
}
