using System.Globalization;
using System.Windows.Controls;

namespace PostageStampTransactionHelper
{
    public class StringToIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            uint i;
            return uint.TryParse(value?.ToString(), out i)
                ? new ValidationResult(true, null)
                : new ValidationResult(false, "Please enter a valid unsigned int value.");
        }
    }

    public class StringToFloatValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            float f;
            return float.TryParse(value?.ToString(), out f)
                ? new ValidationResult(true, null)
                : new ValidationResult(false, "Please enter a valid float value.");
        }
    }

    public class EndsWithValidationRule : ValidationRule
    {
        public string MustEndWith { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (str == null)
                return new ValidationResult(false, "Please enter some text");

            return !str.EndsWith(MustEndWith)
                ? new ValidationResult(false, $"Text must end with '{MustEndWith}'")
                : new ValidationResult(true, null);
        }
    }
}