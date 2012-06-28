using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using Blank.Infrastructure.Validation.Abstract;
using Blank.Infrastructure.Messages;
using Blank.Infrastructure.Validation.Exceptions;

namespace Blank.Infrastructure.NHibernate.Filters
{
    public class Transactional : ActionFilterAttribute
    {
        private ISession session;
        private ITransaction transaction;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.session = DependencyResolver.Current.GetService<ISession>();
            this.transaction = null;
            try
            {
                this.transaction = this.session.BeginTransaction();
            }
            catch
            {
                this.transaction = null;
            }
            base.OnActionExecuting(filterContext);
            
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (filterContext.Exception == null)
            {
                try
                {
                    this.transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    this.transaction.Rollback();
                }
            } else if (this.transaction != null && this.transaction.IsActive)
            {
                this.transaction.Rollback();
            } else if (filterContext.Exception != null && this.transaction != null && this.transaction.IsActive)
            {
                this.transaction.Rollback();
            }
            
            base.OnActionExecuted(filterContext);
        }
    }
}