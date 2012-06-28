using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Blank.Infrastructure.NHibernate.Helper;

namespace Blank.Tests.Helpers.NHibernate
{
    public class NHibernateSessionFactory
    {

        private static Configuration config; 

        public static ISession Session {

            get
            {
                return Fluently.Configure()
                             .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                             //.Mappings(x => x.FluentMappings.AddFromNamespaceOf<PessoaMap>())
                             .ExposeConfiguration(cfg =>
                             {
                                 config = cfg;
                             }).BuildSessionFactory().OpenSession();
            }
        
        }

        public static void BuildSchema(ISession session)
        {
            new SchemaExport(config).Execute(true, true, false, session.Connection, null);
        }

    }
}
