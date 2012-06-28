using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Domain.Security.Services.Abstract
{
    public interface ILeitorDeClassesProtegidas
    {
        IEnumerable<Type> ClassesProtegidasDoNamespace(string classNamespace);
    }
}
