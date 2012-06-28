using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Blank.Domain.Security.Attributes;

namespace Blank.Tests.Unit.Domain.Security.ControllersCompletos
{
    [ControleProtegido("SegundoCompleto", "Segundo Completo")]
    public class SegundoCompletoController : Controller
    {
        [MetodoProtegido("OutroTeste", "outro método de teste")]
        public void OutroTeste() { }
    }
}
