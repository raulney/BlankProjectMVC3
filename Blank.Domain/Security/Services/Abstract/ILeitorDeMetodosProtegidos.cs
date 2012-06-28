using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Blank.Domain.Security.Services.Abstract
{
    public interface ILeitorDeMetodosProtegidos
    {
        IEnumerable<MethodInfo> MetodosProtegidosDaClasse(Type tipoDaClasse);
    }
}
