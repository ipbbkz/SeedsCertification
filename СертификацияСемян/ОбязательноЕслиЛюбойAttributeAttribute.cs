using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace СертификацияСемян;

public class ОбязательноЕслиЛюбойAttribute : ValidationAttribute
{
    private readonly RequiredAttribute внутреннийАтрибут = new RequiredAttribute();
    public string[] зависимыеСвойства { get; set; }
    public List<List<object>> целевыеЗначения { get; set; }

    public ОбязательноЕслиЛюбойAttribute(params object[] dependentPropertiesAndValues)
    {
        ErrorMessageResourceType = typeof(Глобальные);
        ErrorMessageResourceName = nameof(Глобальные.ОбязательноеПоле);

        if (dependentPropertiesAndValues.Length % 2 != 0)
        {
            throw new ArgumentException("The number of dependent properties and values should be even.");
        }

        зависимыеСвойства = new string[dependentPropertiesAndValues.Length / 2];
        целевыеЗначения = new List<List<object>>();

        for (int i = 0; i < dependentPropertiesAndValues.Length; i += 2)
        {
            string зависимоеСвойство = (string)dependentPropertiesAndValues[i];
            IEnumerable значения = (IEnumerable)dependentPropertiesAndValues[i + 1];
            зависимыеСвойства[i / 2] = зависимоеСвойство;
            целевыеЗначения.Add(значения.Cast<object>().ToList());
        }
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (зависимыеСвойства.Length != целевыеЗначения.Count)
        {
            throw new ArgumentException("Number of dependent properties should match the number of target values lists.");
        }

        bool любоеУсловиеУдовлетворено = false;

        for (int i = 0; i < зависимыеСвойства.Length; i++)
        {
            var поле = validationContext.ObjectType.GetProperty(зависимыеСвойства[i]);
            if (поле != null)
            {
                var зависимоеЗначение = поле.GetValue(validationContext.ObjectInstance, null);
                if (целевыеЗначения[i].Contains(зависимоеЗначение))
                {
                    любоеУсловиеУдовлетворено = true;
                    break;
                }
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(зависимыеСвойства[i]));
            }
        }

        if (!любоеУсловиеУдовлетворено)
        {
            return ValidationResult.Success;
        }

        if (!внутреннийАтрибут.IsValid(value))
        {
            string имя = validationContext.DisplayName;
            string настроенноеСообщениеОбОшибке = ErrorMessage ?? "";
            if (настроенноеСообщениеОбОшибке.Length < 1)
                настроенноеСообщениеОбОшибке = $"{имя} is required.";

            return new ValidationResult(настроенноеСообщениеОбОшибке, new[] { validationContext.MemberName });
        }

        return ValidationResult.Success;
    }
}