using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Domain.Security.Models
{
    public class SessionUser
    {
        private string login;
        private IList<Permissao> permissoes;
        private bool superUsuario;
        private string email;

        public SessionUser(string login, IList<Permissao> permissoes, bool superUsuario, string email)
        {
            this.login = login;
            this.permissoes = permissoes;
            this.superUsuario = superUsuario;
            this.email = email;
        }

        public bool HasPermission(string action, string controller)
        {
            return this.superUsuario || this.permissoes.Any(p => p.Metodo == action && p.Interface.Controle == controller);
        }

        public string GetLogin()
        {
            return this.login;
        }

        public string GetEmail()
        {
            return this.email;
        }

    }
}
