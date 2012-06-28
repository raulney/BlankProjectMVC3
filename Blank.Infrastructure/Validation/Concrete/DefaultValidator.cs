using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Infrastructure.Validation.Abstract;
using Blank.Infrastructure.Messages;
using FluentValidation.Attributes;
using System.Reflection;
using FluentValidation.Results;
using Blank.Infrastructure.Validation.Exceptions;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web;
using System.Web.Routing;
using MvcContrib;

namespace Blank.Infrastructure.Validation.Concrete
{
    public class DefaultValidator : IValidator
    {
        private bool hasErros = false;
        private IList<Message> messages = new List<Message>();
        
        public IList<Message> Validates(object objectToBeValidated)
        {

            if(IsNotAnnotadedWithValidationAttribute(objectToBeValidated.GetType()))
            {
                throw new ArgumentException("No Fluent Validation Class Found for this object");
            }

            IList<Message> messages = new List<Message>();

            var validatorClass = GetValidationClass(objectToBeValidated.GetType());

            var validatorObject = GetValidatorInstance(validatorClass);

            MethodInfo[] methodInfos = validatorClass.GetMethods().Where(m => m.Name == "Validate").ToArray();

            ValidationResult validationResult = (ValidationResult) methodInfos[0].Invoke(validatorObject, new Object[] { objectToBeValidated });

            if (validationResult != null && !validationResult.IsValid)
            {
                foreach (var msg in validationResult.Errors)
                {
                    messages.Add(new Message().Of(MessageType.ERROR).Containing(msg.ErrorMessage));
                }
            }

            if (messages.Count > 0)
            {
                this.hasErros = true;
            }

            this.messages = messages;

            return messages;
        }

        private bool IsNotAnnotadedWithValidationAttribute(Type objectType)
        {
            System.Attribute[] classAttributes = System.Attribute.GetCustomAttributes(objectType);
            return classAttributes.Count() == 0 || classAttributes.AsQueryable().Any(at => (at as ValidatorAttribute) == null);
        }

        private Type GetValidationClass(Type type)
        {

            Type validationType = null;

            foreach (Attribute attr in type.GetCustomAttributes(true))
            {
                var validatorAttribute  = attr as ValidatorAttribute;
                if (null != validatorAttribute)
                {
                    validationType = validatorAttribute.ValidatorType;
                }
            }

            return validationType;
        }

        private object GetValidatorInstance(Type validatorType)
        {
            return Activator.CreateInstance(validatorType);    
        }



        public bool HasErros()
        {
            return this.hasErros;
        }


        public void OnValidationErrorRedirectTo<T>(Expression<Action<T>> actionToBeRedirected) where T : Controller
        {
            if (messages.Any())
            {
                RouteValueDictionary values = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression(actionToBeRedirected);
                throw new ValidationException(this.messages, values );
            }
        }
    }
}
