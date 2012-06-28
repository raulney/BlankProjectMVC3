using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blank.Infrastructure.StringHelper
{
    public class BrazilianStringHelper
    {
        public static String RemoveCnpjMask(String maskedString)
        {
            return String.IsNullOrEmpty(maskedString) ? "" : maskedString.Replace(".", "").Replace("/", "").Replace("-", "");
        }

        public static String RemoveCepMask(String maskedString)
        {
            return String.IsNullOrEmpty(maskedString) ? "" : maskedString.Replace("-", "");
        }

        public static String RemovePhoneMask(String maskedString) 
        {
            return String.IsNullOrEmpty(maskedString) ? "" : maskedString.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", ""); 
        }

        public static String PutPhoneMask(String unmaskedString)
        {
            if (String.IsNullOrEmpty(unmaskedString))
            {
                return "";
            }

            return "(" + unmaskedString.Substring(0, 2) + ")" + " " + unmaskedString.Substring(2, 4) + "-" + unmaskedString.Substring(6, 4);
        }
    }
}