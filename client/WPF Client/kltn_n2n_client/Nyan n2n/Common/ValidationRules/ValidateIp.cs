using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nyan_n2n.Common.ValidationRules
{
    public class ValidateIp : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string ip = value as string;
            bool blnTest = false;
            
            Regex regex = new Regex("^((2[0-4]d|25[0-5]|[01]?dd?).){3}(2[0-4]d|25[0-5]|[01]?dd?)$");
            blnTest = regex.IsMatch(ip);
            if (blnTest)
                return ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "格式错误");

        }
    }
}
