using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using Blank.Domain.Security.Services.Abstract;
using Blank.Security.Domain.Services.Concrete;

namespace Blank.Tests.Unit.Domain.Security.Services
{
    [TestFixture]
    class LeitorDeClassesProtegidasTeste
    {

        private ILeitorDeClassesProtegidas reader = new LeitorDeClassesSeguras(Assembly.GetExecutingAssembly());

        [Test]
        public void Deveria_Listar_Todos_As_Classe_Anotadas_Como_Seguras()
        {
            IEnumerable<Type> classesTypes = reader.ClassesProtegidasDoNamespace("Blank.Tests.Unit.Domain.Security.Controllers");
            Assert.NotNull(classesTypes);
            Assert.True(classesTypes.Count() > 0);
        }

        [Test]
        public void Deveria_Avisar_Quando_Nao_Ha_Classes_No_Namespace()
        {
            var exe = Assert.Throws<Exception>(() => reader.ClassesProtegidasDoNamespace("qhjdqghdqghdqw"));
            Assert.AreEqual("Nenhuma classe foi encontrada neste namespace", exe.Message);
        }

        [Test]
        public void Deveria_Avisar_Quando_Nao_Ha_Classes_Anotadas_Como_Seguras_No_Namespace()
        {
            var exe = Assert.Throws<Exception>(() => reader.ClassesProtegidasDoNamespace("Blank.Tests.Helpers.MVC"));
            Assert.AreEqual("Nenhuma classe, anotada com ControleProtegido, foi encontrada neste namespace", exe.Message);
        }

    }
}
