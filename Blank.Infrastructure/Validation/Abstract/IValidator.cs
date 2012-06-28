using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Infrastructure.Messages;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace Blank.Infrastructure.Validation.Abstract
{
    public interface IValidator
    {
        IList<Message> Validates(Object objectToBeValidated);
        void OnValidationErrorRedirectTo<T>(Expression<Action<T>> actionToBeRedirected) where T : Controller;
        bool HasErros();
    }
}
