using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nyan_n2n.Common.ValidationRules
{
    public class ValidatePort : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string port = value as string;
            bool p;
            p = int.TryParse(port, out int n);
            if (p && n >= 1 && n <= 65535)
                return ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "格式错误");

        }
    }
}
