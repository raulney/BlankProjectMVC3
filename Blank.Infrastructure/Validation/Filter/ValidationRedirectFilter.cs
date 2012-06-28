using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Blank.Infrastructure.Validation.Exceptions;
using System.Web.Routing;

namespace Blank.Infrastructure.Validation.Filter
{
    public class ValidationRedirectFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null && (filterContext.Exception as ValidationException) != null)
            {
                ValidationException ex = (filterContext.Exception as ValidationException);

                filterContext.ExceptionHandled = true;
                filterContext.Controller.TempData["mensagens"] = ex.Messages;
                filterContext.Result = new RedirectToRouteResult(ex.RouteValues);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}
