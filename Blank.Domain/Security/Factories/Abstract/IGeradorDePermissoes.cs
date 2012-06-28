using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Models;

namespace Blank.Domain.Security.Factories.Abstract
{
    public interface IGeradorDePermissoes
    {
        IList<Permissao> GeraPermissoesDeInterface(Type tipoDaInterface, Interface interfaceSegura);
    }
}
