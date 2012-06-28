using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Domain.Exceptions
{
    public class RegistroNaoPodeSerCadastradoException : Exception
    {
        public RegistroNaoPodeSerCadastradoException() : base("Registro não pode ser cadastrado") { }
        public RegistroNaoPodeSerCadastradoException(Exception innerException) : base("Registro não pode ser cadastrado", innerException) { }
    }
}
