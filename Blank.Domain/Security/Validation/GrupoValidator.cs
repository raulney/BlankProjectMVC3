using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Models;
using FluentValidation;

namespace Blank.Domain.Security.Validation
{
    public class GrupoValidator : AbstractValidator<Grupo>
    {
        public GrupoValidator()
        {
            RuleFor(g => g.Descricao).NotNull().WithMessage("Descrição é obrigatória");
            RuleFor(g => g.Nome).NotNull().WithMessage("Nome é obrigatório");
        }
    }
}
