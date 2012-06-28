using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Blank.Domain.Security.Factories.Abstract;
using Blank.Domain.Security.Models;
using Blank.Domain.Security.Attributes;
using Blank.Domain.Security.Services.Abstract;

namespace Blank.Domain.Security.Services.Concrete
{
    public class GeradorDePermissoes : IGeradorDePermissoes
    {

        private ILeitorDeMetodosProtegidos leitorDeMetodos;

        public GeradorDePermissoes(ILeitorDeMetodosProtegidos leitorDeMetodos)
        {
            this.leitorDeMetodos = leitorDeMetodos;
        }

        public IList<Permissao> GeraPermissoesDeInterface(Type tipoDaInterface, Interface interfaceSegura)
        {
            IEnumerable<MethodInfo> methods = this.leitorDeMetodos.MetodosProtegidosDaClasse(tipoDaInterface);

            IList<Permissao> permissoes = new List<Permissao>();

            foreach (MethodInfo m in methods)
            {
                Permissao permissao = new Permissao();
                foreach (Attribute attr in m.GetCustomAttributes(true))
                {
                    MetodoProtegido metodoProtegidoAttr = attr as MetodoProtegido;
                    if (metodoProtegidoAttr != null)
                    {

                        permissao.Metodo = metodoProtegidoAttr.NomeMetodo;
                        permissao.Descricao = metodoProtegidoAttr.Descricao;
                        permissao.ValidacaoObrigatoria = metodoProtegidoAttr.ValidacaoObrigatoria;
                    }
                }
                permissao.Interface = interfaceSegura;
                permissoes.Add(permissao);
            }

            return permissoes;
        }
    }
}
