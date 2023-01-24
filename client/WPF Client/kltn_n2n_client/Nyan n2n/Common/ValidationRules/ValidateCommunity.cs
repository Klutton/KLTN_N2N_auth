using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nyan_n2n.Common.ValidationRules
{
    public class ValidateCommunity : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string community = value as string;
            int len = community.Length;
            if (len >= 8 && len <= 12)
                return ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "限制8-12个字符");

        }
    }
}
