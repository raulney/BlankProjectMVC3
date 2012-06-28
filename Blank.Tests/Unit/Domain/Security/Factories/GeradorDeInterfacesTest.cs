using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Blank.Domain.Security.Factories.Abstract;
using Blank.Domain.Security.Services.Abstract;
using Blank.Domain.Security.Models;
using Blank.Domain.Security.Services.Concrete;
using Blank.Tests.Unit.Domain.Security.Controllers;
using Blank.Security.Domain.Services.Concrete;
using Blank.Tests.Unit.Domain.Security.ControllersCompletos;
namespace CasaNet.Tests.Unit.Security.Factory
{
    [TestFixture]
    class GeradorDeInterfacesTest
    {
        private IGeradorDeInterfaces gerador;
        private Mock<ILeitorDeClassesProtegidas> mockReader = new Mock<ILeitorDeClassesProtegidas>();

        [SetUp]
        public void SetUp()
        {
            mockReader.Setup(r => r.ClassesProtegidasDoNamespace("Blank.Tests.Unit.Domain.Security.ControllersCompletos")).Returns(this.RetornaTipos());
            gerador = new GeradorDeInterfaces(mockReader.Object, new GeradorDePermissoes(new LeitorDeMetodosProtegidos()));
        }

        [Test]
        public void Deveria_Gerar_Interfaces_A_Partir_De_Tipos()
        {
            IList<Interface> interfaces = gerador.GeraInterfacesDoNamespace("Blank.Tests.Unit.Domain.Security.ControllersCompletos");
            Assert.NotNull(interfaces);
            Assert.True(interfaces.Count > 0);
            foreach (Interface inter in interfaces)
            {
                
                Assert.NotNull(inter.Controle);
                Assert.NotNull(inter.Descricao);
                Assert.NotNull(inter.Permissoes);
            }
            Assert.AreEqual("Primeiro Completo", interfaces[0].Descricao);
            Assert.AreEqual("PrimeiroCompleto", interfaces[0].Controle);
            Assert.AreEqual("Segundo Completo", interfaces[1].Descricao);
            Assert.AreEqual("SegundoCompleto", interfaces[1].Controle);
        }

        public IEnumerable<Type> RetornaTipos()
        {
            Type[] tipos = new Type[]{
                new PrimeiroCompletoController().GetType(),
                new SegundoCompletoController().GetType()
            };
            return tipos;
        }

    }
}
