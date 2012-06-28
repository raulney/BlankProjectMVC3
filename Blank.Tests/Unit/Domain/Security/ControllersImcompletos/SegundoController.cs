using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Domain.Security.Attributes;
using System.Web.Mvc;

namespace Blank.Tests.Unit.Domain.Security.Controllers
{
    [ControleProtegido("Segundo", "")]
    public class SegundoController : Controller
    {

        [MetodoProtegido("FazAlgo", "")]
        public void FazAlgo() { }

        public void FazMaisAlgo() { }

    }
}
