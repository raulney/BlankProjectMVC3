using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Blank.Domain.Security.Attributes;
using Blank.Domain.Security.Services.Abstract;

namespace Blank.Security.Domain.Services.Concrete
{
    public class LeitorDeMetodosProtegidos : ILeitorDeMetodosProtegidos
    {
        public IEnumerable<MethodInfo> MetodosProtegidosDaClasse(Type tipoDaClasse)
        {
            IEnumerable<MethodInfo> methods = tipoDaClasse.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(m => m.GetCustomAttributes(true).Any(c => (c as MetodoProtegido) != null));
            
            if (methods == null || methods.Any() == false)
            {
                throw new Exception("Esta classe não possui métodos públicos anotados com MetodoProtegido");
            }

            if(methods.Count() < tipoDaClasse.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(m => m.IsPublic).Count())
            {
                throw new Exception("Esta classe possui pelo menos um método público que não possui o atributo MetodoProtegido");
            }

            return methods;
        }
    }
}