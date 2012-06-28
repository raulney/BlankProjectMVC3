using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Blank.Domain.Security.Attributes;

namespace Blank.Tests.Unit.Domain.Security.Controllers
{
    [ControleProtegido("Primeiro", "")]
    public class PrimeiroController : Controller
    {
    }
}
