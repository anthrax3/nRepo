using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Configuration;
using NHibernate.Tool.hbm2ddl;

namespace AI.nRepo
{
    public class SessionFactoryBuilder
    {
        readonly ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory;
            }
        }

        public SessionFactoryBuilder()
        {
            //var connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Frdconn"].ConnectionString;
            //var configurer = MsSqlConfiguration.MsSql2005.ConnectionString(connStr);
            //NHibernate.Cfg.Configuration configuration = null;

            //_sessionFactory = Fluently.Configure()
            //.Database(configurer)
            //.Mappings(m =>m.FluentMappings.AddFromAssembly(typeof(EntityBaseMap<>).Assembly))
            
            //.ExposeConfiguration(cfg =>
            //                     {
            //                         configuration = cfg;
            //                         cfg.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, typeof(List<>).AssemblyQualifiedName);
            //                         cfg.SetProperty(NHibernate.Cfg.Environment.BatchSize, "100");
            //                     })
            //.BuildSessionFactory();

        }

        private void UpdateSchema(NHibernate.Cfg.Configuration cfg)
        {
            NHibernate.Tool.hbm2ddl.SchemaUpdate update = new SchemaUpdate(cfg);
            update.Execute(false, true);
        }
    }
}
