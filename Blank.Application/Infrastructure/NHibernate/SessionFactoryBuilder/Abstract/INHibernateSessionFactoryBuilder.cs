using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Blank.Application.Infrastructure.NHibernate.SessionFactoryBuilder
{
    public interface INHibernateSessionFactoryBuilder
    {
        ISessionFactory GetSessionFactory();
    }
}
