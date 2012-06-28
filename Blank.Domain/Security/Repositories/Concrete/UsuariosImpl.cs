using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Blank.Domain.Security.Repositories.Abstract;
using Blank.Domain.Security.Models;
using Blank.Domain.Exceptions;
using NHibernate.Criterion;
using NHibernate.Exceptions;

namespace Blank.Domain.Security.Repositories.Concrete
{
    public class UsuariosImpl : IUsuarios
    {
        private ISession session;

        public UsuariosImpl(ISession session)
        {
            this.session = session;
        }

        public void Insere(Usuario usuario)
        {
            try
            {
                session.Save(usuario);
                session.Flush();
            }
            catch(GenericADOException ex)
            {
                throw new RegistroNaoPodeSerCadastradoException(ex);
            }
            
        }

        public void Atualiza(Usuario usuario)
        {
            try
            {
                session.Update(usuario);
                session.Flush();
            }
            catch (GenericADOException ex)
            {
                throw new RegistroNaoPodeSerCadastradoException(ex);
            }
             
        }

        public void Inativa(Usuario usuario)
        {
            usuario.Inativo = true;
            Atualiza(usuario);
        }


        public void Reativa(Usuario usuario)
        {
            usuario.Inativo = false;
            Atualiza(usuario);
        }

        public IList<Usuario> ListaTodosAtivos()
        {
            return session.QueryOver<Usuario>().Where(u => u.Inativo == false).OrderBy(u => u.Nome).Asc.List();
        }

        public Usuario BuscaPorIdentificador(short identificador)
        {
            return session.QueryOver<Usuario>().Where(u => u.Id == identificador).SingleOrDefault();
        }

        public Usuario BuscaPorLoginAtivo(string login)
        {
            return session.QueryOver<Usuario>().WhereRestrictionOn(u => u.Login).IsLike(login).Where(u => u.Inativo == false).SingleOrDefault();
        }

    }
}
