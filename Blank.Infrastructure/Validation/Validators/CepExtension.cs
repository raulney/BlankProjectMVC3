using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace Blank.Infrastructure.Validation.Validators
{
    public static class CepExtension
    {
        public static IRuleBuilderOptions<T, TElement> CEP<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new Cep<TElement>());
        }
    }
}
