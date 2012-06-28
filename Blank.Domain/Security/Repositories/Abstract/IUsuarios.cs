using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Models;

namespace Blank.Domain.Security.Repositories.Abstract
{
    public interface IUsuarios
    {
        void Insere(Usuario usuario);

        void Atualiza(Usuario usuario);

        void Inativa(Usuario usuario);

        void Reativa(Usuario usuario);

        Usuario BuscaPorIdentificador(short identificador);

        Usuario BuscaPorLoginAtivo(string login);

        IList<Usuario> ListaTodosAtivos();
        
    }
}
