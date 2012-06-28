using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Domain.Security.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class ControleProtegido : System.Attribute
    {
        public string NomeControle { get; private set; }
        public string Descricao { get; private set; }
        public bool ValidacaoObrigatoria { get; private set; }

        public ControleProtegido(string nomeControle, string descricao, bool validacaoObrigatoria = true)
        {
            this.NomeControle = nomeControle;
             this.Descricao = descricao;
             this.ValidacaoObrigatoria = validacaoObrigatoria;
        }
    
    }
}
