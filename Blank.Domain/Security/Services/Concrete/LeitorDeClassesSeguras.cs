using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Blank.Domain.Security.Attributes;
using Blank.Domain.Security.Services.Abstract;

namespace Blank.Security.Domain.Services.Concrete
{
    public class LeitorDeClassesSeguras : ILeitorDeClassesProtegidas
    {

        private Assembly assembly;

        public LeitorDeClassesSeguras(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public IEnumerable<Type> ClassesProtegidasDoNamespace(string classNamespace)
        {
            IEnumerable<Type> classes = assembly.GetTypes().Where(type => type.Namespace == classNamespace);

            if (classes == null || classes.Count() == 0)
            {
                throw new Exception("Nenhuma classe foi encontrada neste namespace");
            }

            IEnumerable<Type> annotadedClasses = classes.Where(type => System.Attribute.GetCustomAttributes(type).Count() > 0 && System.Attribute.GetCustomAttributes(type).AsQueryable().Any(at => (at as ControleProtegido) != null));

            if (annotadedClasses == null || annotadedClasses.Count() == 0)
            {
                throw new Exception("Nenhuma classe, anotada com ControleProtegido, foi encontrada neste namespace");
            }

            return annotadedClasses;

        }
    }
}