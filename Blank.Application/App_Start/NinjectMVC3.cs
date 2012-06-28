[assembly: WebActivator.PreApplicationStartMethod(typeof(Blank.Application.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Blank.Application.App_Start.NinjectMVC3), "Stop")]

namespace Blank.Application.App_Start
{
    using System.Reflection;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;
    using Blank.Infrastructure.Validation.Abstract;
    using Blank.Infrastructure.Validation.Concrete;
    using Blank.Application.Infrastructure.NHibernate.SessionFactoryBuilder;
    using Blank.Application.Infrastructure.NHibernate.SessionFactory;
    using NHibernate;
    using Blank.Infrastructure.Encryptation.Abstract;
    using Blank.Infrastructure.Security;
    using Blank.Infrastructure.XmlHelper.Abstract;
    using Blank.Infrastructure.XmlHelper.Concrete;
    using Blank.Domain.Security.Repositories.Abstract;
    using Blank.Domain.Security.Repositories.Concrete;
    using Blank.Domain.Security.Services.Abstract;
    using Blank.Security.Domain.Services.Concrete;
    using Blank.Domain.Security.Factories.Abstract;
    using Blank.Domain.Security.Services.Concrete;

    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {

            //Infraestrutura

            kernel.Bind<IValidator>().To<DefaultValidator>().InRequestScope();
            kernel.Bind<INHibernateSessionFactoryBuilder>().To<DefaultNHibernateSessionFactoryBuilder>().InSingletonScope().Named("Default");
            kernel.Bind<ISession>().ToMethod(ctx => ctx.Kernel.Get<INHibernateSessionFactoryBuilder>("Default").GetSessionFactory().OpenSession()).InRequestScope();
            kernel.Bind<ICipher>().To<DefaultCipher>().InSingletonScope();
            kernel.Bind<IDeserializer>().To<DefaultDeserializer>().InSingletonScope();
            kernel.Bind<IXmlReader>().To<DefaultXmlReader>().InSingletonScope();
            
            //Segurança

            kernel.Bind<IGrupos>().To<GruposImpl>();
            kernel.Bind<IUsuarios>().To<UsuariosImpl>();
            kernel.Bind<IInterfaces>().To<InterfacesImpl>();
            kernel.Bind<ILeitorDeClassesProtegidas>().ToConstant(new LeitorDeClassesSeguras(Assembly.GetExecutingAssembly()));
            kernel.Bind<ILeitorDeMetodosProtegidos>().To<LeitorDeMetodosProtegidos>();
            kernel.Bind<IGeradorDeInterfaces>().To<GeradorDeInterfaces>();
            kernel.Bind<IGeradorDePermissoes>().To<GeradorDePermissoes>();

        }        
    }
}
