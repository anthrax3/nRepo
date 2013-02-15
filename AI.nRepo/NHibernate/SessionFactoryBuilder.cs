using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Configuration;
using NHibernate.Event;
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

        public SessionFactoryBuilder(IDatabasePlatform platform, string connStr, IList<Assembly> assemblies, bool updateSchema, object preSaveHandler,string defaultSchema)
        {
            var configurer = platform.AsNHibernateConfiguration(connStr) as IPersistenceConfigurer;
            var theUpdateHandler = preSaveHandler as ISaveOrUpdateEventListener;
            NHibernate.Cfg.Configuration configuration = null;

            _sessionFactory = Fluently.Configure()
            .Database(configurer)
            .Mappings(m => assemblies.ToList().ForEach(asm=> m.FluentMappings.AddFromAssembly(asm)))

            .ExposeConfiguration(cfg =>
                                 {
                                     configuration = cfg;
                                     cfg.SetProperty(NHibernate.Cfg.Environment.CollectionTypeFactoryClass, typeof(List<>).AssemblyQualifiedName);
                                     cfg.SetProperty(NHibernate.Cfg.Environment.PrepareSql, false.ToString());
                                     cfg.SetProperty(NHibernate.Cfg.Environment.ShowSql,
                                                     System.Diagnostics.Debugger.IsAttached.ToString());

                                     if(!String.IsNullOrEmpty(defaultSchema))
                                         cfg.SetProperty(NHibernate.Cfg.Environment.DefaultSchema, defaultSchema);
                                     if (theUpdateHandler != null)
                                     {
                                         cfg.AppendListeners(ListenerType.PreUpdate, new[] {theUpdateHandler});
                                         cfg.AppendListeners(ListenerType.PreInsert, new[] {theUpdateHandler});
                                     }


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
