using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Validators;
using Blank.Infrastructure.StringHelper;

namespace Blank.Infrastructure.Validation.Validators
{
    public class BrazilianPhoneNumber<T> : PropertyValidator 
    {
        public BrazilianPhoneNumber() : base("Telefone inválido") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (String.IsNullOrEmpty(context.PropertyValue as string))
            {
                return true;
            }

            return BrazilianStringHelper.RemovePhoneMask(context.PropertyValue as string).Length == 10;
        }
    }
}
