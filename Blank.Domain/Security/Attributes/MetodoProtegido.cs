using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Domain.Security.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class MetodoProtegido : System.Attribute
    {
        public string NomeMetodo { get; private set;}
        public string Descricao { get; private set; }
        public bool ValidacaoObrigatoria { get; private set; }

        public MetodoProtegido(string nomeMetodo, string descricao, bool validacaoObrigatoria = true)
        {
            this.NomeMetodo = nomeMetodo;
            this.Descricao = descricao;
            this.ValidacaoObrigatoria = validacaoObrigatoria;
        }
    }
}
