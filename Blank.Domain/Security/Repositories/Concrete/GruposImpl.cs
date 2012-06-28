using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using Blank.Domain.Security.Repositories.Abstract;
using Blank.Domain.Security.Models;
using NHibernate.Exceptions;
using Blank.Domain.Exceptions;

namespace Blank.Domain.Security.Repositories.Concrete
{
    public class GruposImpl : IGrupos
    {
        private ISession session;

        public GruposImpl(ISession session)
        {
            this.session = session;
        }

        public void Insere(Grupo grupo)
        {
            try
            {
                session.Save(grupo);
                session.Flush();
            }
            catch(GenericADOException ex)
            {
                throw new RegistroNaoPodeSerCadastradoException(ex);
            }
            
        }

        public void Atualiza(Grupo grupo)
        {
            try
            {
                session.Update(grupo);
                session.Flush();
            }
            catch (GenericADOException ex)
            {
                throw new RegistroNaoPodeSerCadastradoException(ex);
            }
            
        }

        public void Inativa(Grupo grupo)
        {
            grupo.Inativo = true;
            Atualiza(grupo);
        }

        public void Reativa(Grupo grupo)
        {
            grupo.Inativo = false;
            Atualiza(grupo);
        }

        public Grupo BuscaPorIdentificador(short identificador)
        {
            return session.QueryOver<Grupo>().Where(g => g.Id == identificador).SingleOrDefault();
        }

        public IList<Grupo> ListaTodosAtivos()
        {
            return session.QueryOver<Grupo>().Where(g => g.Inativo == false).List();
        }

        public IList<Grupo> ListaPorNomePorDescricaoInatividade(Grupo grupo)
        {
           
            var busca = session.QueryOver<Grupo>();

            if (String.IsNullOrEmpty(grupo.Nome) == false)
            {
                busca.WhereRestrictionOn(g => g.Nome).IsLike(grupo.Nome, MatchMode.Anywhere);
            }

            if (String.IsNullOrEmpty(grupo.Descricao) == false)
            {
                busca.WhereRestrictionOn(g => g.Descricao).IsLike(grupo.Nome, MatchMode.Anywhere);
            }

            if (grupo.EstaAtivo())
            {
                busca.Where(g => g.Inativo == false);
            }
            else
            {
                busca.Where(g => g.Inativo == true);
            }

            return busca.OrderBy(g => g.Nome).Asc.List();
        
        }
    
    }
}
