using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Validation;
using FluentValidation.Attributes;

namespace Blank.Domain.Security.Models
{
    [Validator(typeof(GrupoValidator))]
    public class Grupo
    {
        public virtual short Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool Inativo { get; set; }
        public virtual IList<Permissao> Permissoes { get; set; }
        public virtual IList<Usuario> Usuarios { get; set; }
        public virtual bool Selecionado { get; set; }

        public virtual bool EstaAtivo() {
            return this.Inativo == false;
        }

        public virtual bool EstaInativo() {
            return this.Inativo;
        }

        public virtual bool PossuiPermissoes()
        {
            return Permissoes != null && Permissoes.Count > 0;
        }

        public virtual bool PossuiUsuarios()
        {
            return Usuarios != null && Usuarios.Count > 0;
        }

        public virtual bool EstaVazio() { 
            return Id == 0 && String.IsNullOrEmpty(Nome) && String.IsNullOrEmpty(Descricao) && Inativo == false;
        }

    }
}
