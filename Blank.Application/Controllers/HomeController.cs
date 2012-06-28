using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blank.Domain.Security.Attributes;

namespace Blank.Application.Controllers
{
    [ControleProtegido("Home", "Home", false)]
    public class HomeController : Controller
    {
        [HttpGet]
        [MetodoProtegido("Index", "Index da aplicação", false)]
        public ActionResult Index()
        {
            return View();
        }

    }
}
