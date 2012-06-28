using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Validators;
using Blank.Infrastructure.Validation.Helpers;

namespace Blank.Infrastructure.Validation.Validators
{
    public class Cpf<T> : PropertyValidator
    {
        public Cpf() : base("Cpf inválido") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return isValidCPF(context.PropertyValue as string);
        }

        public static bool isValidCPF(string cpf)
        {
            return cpf.IsValidCpf();
        }
    }
}
