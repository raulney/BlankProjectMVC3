using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Blank.Infrastructure.NHibernate.Helper;
using Blank.Application.Infrastructure.NHibernate.SessionFactoryBuilder;
using Blank.Application.Infrastructure.NHibernate.Maps;

namespace Blank.Application.Infrastructure.NHibernate.SessionFactory
{
    public class DefaultNHibernateSessionFactoryBuilder : INHibernateSessionFactoryBuilder
    {
        private static ISessionFactory _sessionFactory;

        public ISessionFactory GetSessionFactory()
        {

            if (_sessionFactory == null)
            {
                _sessionFactory = CreateSessionFactory();
            }

            return _sessionFactory;

        }

        private ISessionFactory CreateSessionFactory()
        {
            log4net.Config.XmlConfigurator.Configure();
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2008
                           .ConnectionString(c => c.FromConnectionStringWithKey("BlankDatabase")).ShowSql())
                           .Mappings(x => x.FluentMappings.AddFromNamespaceOf<GrupoMap>())
                           .ExposeConfiguration(BuildSchema)
                           .BuildSessionFactory();
        }

        private void BuildSchema(Configuration cfg)
        {
            new SchemaUpdate(cfg).Execute(true, true);
        }

    }
}