using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Configuration;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using System.Reflection;

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

        public SessionFactoryBuilder(string connStr, IList<Assembly> assemblies, bool updateSchema)
        {
            var configurer = MsSqlConfiguration.MsSql2005.ConnectionString(connStr);
            NHibernate.Cfg.Configuration configuration = null;

            _sessionFactory = Fluently.Configure()
            .Database(configurer)
            .Mappings(m => assemblies.ToList().ForEach(asm=> m.FluentMappings.AddFromAssembly(asm)))

            .ExposeConfiguration(cfg =>
                                 {
                                     configuration = cfg;
                                     cfg.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, typeof(List<>).AssemblyQualifiedName);
                                     
                                 })
            .BuildSessionFactory();

            if (updateSchema)
                UpdateSchema(configuration);
            

        }

        private void UpdateSchema(NHibernate.Cfg.Configuration cfg)
        {
            NHibernate.Tool.hbm2ddl.SchemaUpdate update = new SchemaUpdate(cfg);
            update.Execute(false, true);
        } 
    }
}
