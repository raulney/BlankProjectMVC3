using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Models;

namespace Blank.Domain.Security.Repositories.Abstract
{
    public interface IInterfaces
    {
        Interface BuscaPorIdentificador(short identificador);
        IList<Interface> ListaTodas();
        IList<Permissao> ListaTodasPermissoesDeInterface(Interface interfaceSegura);
        Permissao BuscaPermissaoDeInterfacePorIdentificador(short identificador);
        void SalvaInterfaces(IList<Interface> interfaces);
        Interface BuscaPorController(string nomeDoController);
    }
}
