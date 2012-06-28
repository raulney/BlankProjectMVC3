using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Models;

namespace Blank.Domain.Security.Repositories.Abstract
{
    public interface IGrupos
    {
        void Insere(Grupo grupo);

        void Atualiza(Grupo grupo);

        void Inativa(Grupo grupo);

        void Reativa(Grupo grupo);

        Grupo BuscaPorIdentificador(short identificador);

        IList<Grupo> ListaTodosAtivos();

        IList<Grupo> ListaPorNomePorDescricaoInatividade(Grupo grupo);
    }
}
