using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Domain.Security.Models
{
    public class Permissao
    {
        public virtual short Id { get; set; }
        public virtual string Metodo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool ValidacaoObrigatoria { get; set; }
        public virtual Interface Interface { get; set; }
        public virtual bool Selecionado { get; set; }

    }
}
