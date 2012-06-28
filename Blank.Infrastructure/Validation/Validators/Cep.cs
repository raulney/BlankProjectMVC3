using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Validators;
using Blank.Infrastructure.StringHelper;

namespace Blank.Infrastructure.Validation.Validators
{
    public class Cep<T> : PropertyValidator
    {

        public Cep() : base("Cep inválido") {}

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var cep = context.PropertyValue as string;
            return BrazilianStringHelper.RemoveCepMask(cep).Length == 8;
        }
    }
}
