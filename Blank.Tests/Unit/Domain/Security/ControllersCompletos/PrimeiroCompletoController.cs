using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Blank.Domain.Security.Attributes;

namespace Blank.Tests.Unit.Domain.Security.ControllersCompletos
{
    [ControleProtegido("PrimeiroCompleto", "Primeiro Completo")]
    public class PrimeiroCompletoController : Controller
    {
        [MetodoProtegido("Teste", "método de teste")]
        public void Teste() { }
    }
}
