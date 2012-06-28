using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Blank.Infrastructure.Validation.Validators
{
    public static class CnpjExtension
    {
        public static IRuleBuilderOptions<T, TElement> CNPJ<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Cnpj<TElement>());
        }
    }
}
