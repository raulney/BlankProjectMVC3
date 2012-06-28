using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Blank.Tests.Helpers.NHibernate;

namespace Blank.Tests.Unit.Domain.Repositories
{
    public class RepositoryTestCase
    {
        protected ISession session;

        private ISession ConfigureNHibernateSession()
        {
            return NHibernateSessionFactory.Session;
        }

        [SetUp]
        public void PrepareTest()
        {
            session = ConfigureNHibernateSession();
            NHibernateSessionFactory.BuildSchema(session);
            this.session.BeginTransaction();
        }

        [TearDown]
        public void FinishTest()
        {
            session.Transaction.Rollback();
            session.Dispose();
        }
    }
}
