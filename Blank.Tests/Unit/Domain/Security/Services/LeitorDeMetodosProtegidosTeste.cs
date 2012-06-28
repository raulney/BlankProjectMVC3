using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using Blank.Domain.Security.Services.Abstract;
using Blank.Security.Domain.Services.Concrete;
using Blank.Domain.Security.Models;
using Blank.Tests.Unit.Domain.Security.ControllersCompletos;
using Blank.Tests.Unit.Domain.Security.Controllers;

namespace Blank.Tests.Unit.Domain.Security.Services
{
    [TestFixture]
    class LeitorDeMetodosProtegidosTeste
    {
        private ILeitorDeMetodosProtegidos reader = new LeitorDeMetodosProtegidos();

        [Test]
        public void Deveria_Listar_Todos_Os_Metodos_Publicos_Anotados_Como_Protegidos()
        {
            IEnumerable<MethodInfo> metodos = this.reader.MetodosProtegidosDaClasse(typeof(PrimeiroCompletoController));
            Assert.NotNull(metodos);
            Assert.True(metodos.Count() > 0);
        }

        [Test]
        public void Nao_Deveria_Gerar_Informacoes_De_Metodos_Quando_Nao_Ha_Metodos_Publicos_Anotados_Como_Protegidos() {
            var exe = Assert.Throws<Exception>(() => this.reader.MetodosProtegidosDaClasse(typeof(PrimeiroController)));
            Assert.AreEqual("Esta classe não possui métodos públicos anotados com MetodoProtegido", exe.Message);
        }

        [Test]
        public void Nao_Deveria_Gerar_Informacoes_De_Metodos_Quando_Nao_Ha_Pelo_Menos_Um_Metodo_Publico_Anotado_Como_Protegido() {
            var exe = Assert.Throws<Exception>(() => this.reader.MetodosProtegidosDaClasse(typeof(SegundoController)));
            Assert.AreEqual("Esta classe possui pelo menos um método público que não possui o atributo MetodoProtegido", exe.Message);
        }

    }
}
