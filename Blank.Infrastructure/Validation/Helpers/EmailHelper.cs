using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Blank.Infrastructure.Validation.Helpers
{
    public static class EmailHelper
    {
        public static bool isValidEmail(this string emailToBeValidated)
        {
            return IsEmail(emailToBeValidated);
        }

        public static bool isInvalidEmail(this string emailToBeValidated)
        {
            return !IsEmail(emailToBeValidated);
        }

        private static bool IsEmail(string text)
        {
            return Regex.IsMatch(text, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }
    }
}
