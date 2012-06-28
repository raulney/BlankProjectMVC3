using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Blank.Infrastructure.StringHelper
{
    public static class UtilsHelper
    {
        public static bool IsNotNullOrNotEmpty(this string stringToBeEvaluated)
        {
            return !String.IsNullOrEmpty(stringToBeEvaluated);
        }

        public static string Reverse(this string stringToBeReverse)
        {
            if (IsNotNullOrNotEmpty(stringToBeReverse))
            {
                char[] arr = stringToBeReverse.ToCharArray();
                Array.Reverse(arr);
                return new string(arr);
            }

            return stringToBeReverse;
        }

    }
}
