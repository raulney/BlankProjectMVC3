using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Blank.Domain.Security.Factories.Abstract;
using Blank.Domain.Security.Models;
using Blank.Domain.Security.Repositories.Abstract;
using Blank.Infrastructure.Validation.Filter;
using Blank.Infrastructure.NHibernate.Filters;
using MvcContrib.Filters;

namespace Blank.Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ModelStateToTempDataAttribute() { Order = 0 });
            filters.Add(new ValidationRedirectFilter() { Order = 1 });
            filters.Add(new Transactional() { Order = 2});
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //Home
            routes.MapRoute("Padrao", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("Home", "home", new  { controller = "Home", action = "Index"});
            
            //Grupos
            routes.MapRoute("BuscaGrupos", "grupos", new { controller = "Grupos", action = "Index" });
            routes.MapRoute("NovoGrupo", "grupos/novo", new { controller = "Grupos", action = "Novo"});
            routes.MapRoute("EditaGrupo", "grupos/edita/{id}", new { controller = "Grupos", action = "Edita", id = UrlParameter.Optional});
            routes.MapRoute("CadastraNovoGrupo", "grupos/cadastra", new { controller = "Grupos", action = "Insere"});
            routes.MapRoute("AtualizaGrupo", "grupos/atualiza", new { controller = "Grupos", action = "Atualiza" });
            routes.MapRoute("InativaGrupo", "grupos/inativa", new { controller = "Grupos", action = "Inativa", id = UrlParameter.Optional });
            routes.MapRoute("ReativaGrupo", "grupos/ativa", new { controller = "Grupos", action = "Ativa", id = UrlParameter.Optional });

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            CadastraInterfaces();
        }

        private void CadastraInterfaces()
        {
            IGeradorDeInterfaces geradorDeInterfaces = DependencyResolver.Current.GetService<IGeradorDeInterfaces>();
            IList<Interface> interfacesSeguras = geradorDeInterfaces.GeraInterfacesDoNamespace("Blank.Application.Controllers");
            IInterfaces interfaces = DependencyResolver.Current.GetService<IInterfaces>();
            interfaces.SalvaInterfaces(interfacesSeguras);
        }

    }
}