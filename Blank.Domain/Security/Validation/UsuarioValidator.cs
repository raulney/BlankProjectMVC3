using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Models;
using FluentValidation;
using Blank.Infrastructure.Validation.Validators;

namespace Blank.Domain.Security.Domain.Validation
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(usuario => usuario.Login).NotNull().WithMessage("Login é obrigatório");
            RuleFor(usuario => usuario.Nome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(usuario => usuario.Senha).NotEmpty().WithMessage("Senha é obrigatória");
            RuleFor(usuario => usuario.ConfirmacaoSenha).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Confirmação é obrigatória").Equal(usuario => usuario.Senha).WithMessage("Senha e confirmação não são iguais");
            RuleFor(usuario => usuario.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("E-mail é obrigatório").EmailAddress().WithMessage("E-mail está em formato inválido");
        }

    }
}
