using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Infrastructure.Messages;
using System.Web.Routing;

namespace Blank.Infrastructure.Validation.Exceptions
{
    public class ValidationException : Exception
    {

        public IList<Message> Messages{ get; private set;}
        public RouteValueDictionary RouteValues { get; private set; }

        public ValidationException(IList<Message> messages, RouteValueDictionary routeValues) : base("Validation error"){
            this.RouteValues = routeValues;
            this.Messages = messages;
        }
    }
}
