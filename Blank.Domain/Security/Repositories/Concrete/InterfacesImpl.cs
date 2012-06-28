using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Repositories.Abstract;
using NHibernate;
using Blank.Domain.Security.Models;
using NHibernate.SqlCommand;
using NHibernate.Criterion;

namespace Blank.Domain.Security.Repositories.Concrete
{
    public class InterfacesImpl : IInterfaces
    {
        private ISession session;

        public InterfacesImpl(ISession session)
        {
            this.session = session;
        }

        public IList<Interface> ListaTodas()
        {
            return session.QueryOver<Interface>().OrderBy(p => p.Descricao).Asc.List<Interface>();
        }

        public IList<Permissao> ListaTodasPermissoesDeInterface(Interface interfaceSegura)
        {
            return session.QueryOver<Permissao>().OrderBy(p => p.Descricao).Asc.Inner.JoinQueryOver(p => p.Interface).Where(i => i.Id == interfaceSegura.Id).List();
        }

        public Interface BuscaPorIdentificador(short identificador)
        {
            return session.QueryOver<Interface>().Where(i => i.Id == identificador).SingleOrDefault();
        }

        public Permissao BuscaPermissaoDeInterfacePorIdentificador(short identificador)
        {
            return session.QueryOver<Permissao>().Where(p => p.Id == identificador).SingleOrDefault();
        }

        public void SalvaInterfaces(IList<Interface> interfaces)
        {

            try
            {
                session.BeginTransaction();
                foreach (Interface interfaceSegura in interfaces)
                {
                    Interface interfaceDoBanco = BuscaPorController(interfaceSegura.Controle);
                    if (interfaceDoBanco == null)
                    {
                        session.Save(interfaceSegura);
                    }
                    else
                    {
                        interfaceDoBanco.Descricao = interfaceSegura.Descricao;
                        interfaceDoBanco.ValidacaoObrigatoria = interfaceSegura.ValidacaoObrigatoria;

                        IList<Permissao> permissoesNovas = new List<Permissao>();

                        foreach (Permissao permissao in interfaceSegura.Permissoes)
                        {

                            IEnumerable<Permissao> permissaoParaAtualizar = interfaceDoBanco.Permissoes.Where(p => p.Metodo == permissao.Metodo);

                            if (permissaoParaAtualizar.Count() == 0)
                            {
                                permissoesNovas.Add(permissao);
                            }
                            else
                            {
                                Permissao p = permissaoParaAtualizar.ToList()[0];
                                p.Descricao = permissao.Descricao;
                                p.ValidacaoObrigatoria = permissao.ValidacaoObrigatoria;
                            }
                        }

                        if (permissoesNovas.Count() > 0)
                        {
                            foreach (Permissao permissao in permissoesNovas)
                            {
                                permissao.Interface = interfaceDoBanco;
                                interfaceDoBanco.Permissoes.Add(permissao);
                            }
                        }
                        session.Update(interfaceDoBanco);
                    }

                }
                session.Transaction.Commit();
            }
            catch
            {
                session.Transaction.Rollback();
            }
            session.Close();
            
        }

        public Interface BuscaPorController(string nomeDoController)
        {
            return session.QueryOver<Interface>().WhereRestrictionOn(i => i.Controle).IsLike(nomeDoController).SingleOrDefault();
        }

    }
}
