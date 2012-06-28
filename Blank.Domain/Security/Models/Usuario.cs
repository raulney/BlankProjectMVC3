using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Attributes;
using Blank.Domain.Security.Domain.Validation;

namespace Blank.Domain.Security.Models
{
    [Validator(typeof(UsuarioValidator))]
    public class Usuario
    {
        public virtual short Id { get; set; }
        public virtual string Login { get; set; }
        public virtual string Email { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Senha { get; set; }

        public virtual bool Inativo { get; set; }
        public virtual bool SuperUsuario { get; set; }
        public virtual IList<Grupo> Grupos { get; set; }

        //Campo transiente para saber se as senhas conferem
        public virtual string ConfirmacaoSenha { get; set; }
        //Campo transiente para saber se o mesmo foi selecionado 
        public virtual bool Selecionado { get; set; }

        public virtual bool EstaAtivo() {
            return this.Inativo == false;
        }

        public virtual bool EstaInativo() {
            return this.Inativo;
        }

    }
}
