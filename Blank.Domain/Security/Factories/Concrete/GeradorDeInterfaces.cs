using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Factories.Abstract;
using Blank.Security.Domain.Services.Concrete;
using Blank.Domain.Security.Services.Abstract;
using Blank.Domain.Security.Models;
using Blank.Domain.Security.Attributes;

namespace Blank.Domain.Security.Services.Concrete
{
    public class GeradorDeInterfaces : IGeradorDeInterfaces
    {
        private ILeitorDeClassesProtegidas reader;
        private IGeradorDePermissoes geradorDePermissoes;

        public GeradorDeInterfaces(ILeitorDeClassesProtegidas reader, IGeradorDePermissoes geradorDePermissoes)
        {
            this.reader = reader;
            this.geradorDePermissoes = geradorDePermissoes;
        }

        public IList<Interface> GeraInterfacesDoNamespace(string interfacesNamespace)
        {
            IEnumerable<Type> tipos = reader.ClassesProtegidasDoNamespace(interfacesNamespace);

            IList<Interface> interfaces = new List<Interface>();

            foreach (Type tipo in tipos)
            {
                Interface interfaceSegura = new Interface();
                foreach (Attribute attr in tipo.GetCustomAttributes(true))
                {
                    var atributoControleProtegido = attr as ControleProtegido;
                    if (null != atributoControleProtegido)
                    {
                        interfaceSegura.Controle = atributoControleProtegido.NomeControle;
                        interfaceSegura.Descricao = atributoControleProtegido.Descricao;
                        interfaceSegura.ValidacaoObrigatoria = atributoControleProtegido.ValidacaoObrigatoria;
                    }
                }
                interfaceSegura.Permissoes = geradorDePermissoes.GeraPermissoesDeInterface(tipo, interfaceSegura);
                interfaces.Add(interfaceSegura);
            }

            return interfaces;
        }
    }
}
