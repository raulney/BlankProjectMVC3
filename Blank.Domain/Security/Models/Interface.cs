using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Domain.Security.Models
{
    public class Interface
    {
        public virtual short Id { get; set; }
        public virtual string Controle { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool ValidacaoObrigatoria { get; set; }
        public virtual IList<Permissao> Permissoes { get; set; }

        public virtual bool IsLoginPage()
        {
            return Controle == "Login" && Permissoes.Any(p => p.Metodo == "Index");
        }

        public virtual bool IsLoginAction()
        {
            return Controle == "Login" && Permissoes.Any(p => p.Metodo == "Login");
        }

        public virtual bool IsLogoutPage()
        {
            return Controle == "Login" && Permissoes.Any(p => p.Metodo == "Logout");
        }

        public virtual bool HasNotRequiredAction(string action)
        {

            bool possuiAction = this.Permissoes.Any(p => p.Metodo == action && !p.ValidacaoObrigatoria);

            return this.Permissoes != null && possuiAction;
        }
    }
}
