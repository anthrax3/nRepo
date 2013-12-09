using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AI.nRepo.Configuration;
using AI.nRepo.DbPlatforms;
using NHibernate.Linq.Functions;

namespace AI.nRepo.NHibernate
{
    using System.Runtime.InteropServices;

    public class NHibernateConfiguration : IRepositoryConfiguration
    {
        private readonly IList<Assembly> _assemblies;
        private bool _updateSchema;
        private IDatabasePlatform _platform;
        private string _defaultSchema = "dbo";
        private const string DefaultConnection = "Default";
        private string _connectionString;
        private bool _showSql;
        protected SessionFactoryBuilder _sessionFactoryBuilder;
        private ILinqToHqlGeneratorsRegistry _linqExtension;
        private Action<global::NHibernate.Cfg.Configuration> _exposedConfiguration;
        public NHibernateConfiguration()
        {
            _assemblies = new List<Assembly>();
            this._platform = new MsSqlServer.Server2012Platform();
        
        }

        public NHibernateConfiguration AddMappings(Assembly assembly)
        {
            this._assemblies.Add(assembly);
            return this;
        }

        public NHibernateConfiguration ConnectionString(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }

        public NHibernateConfiguration ExposeConfiguration(
            Action<global::NHibernate.Cfg.Configuration> exposedConfig)
        {
            this._exposedConfiguration = exposedConfig;
            return this;
        }

        public NHibernateConfiguration UpdateSchemaOnDebug()
        {
            _updateSchema = true;
            return this;
        }

        public NHibernateConfiguration ShowSql(bool showSql)
        {
            this._showSql = showSql;
            return this;
        }

        public NHibernateConfiguration DefaultSchema(string schema)
        {
            this._defaultSchema = schema;
            return this;
        }

        public NHibernateConfiguration Platform<TPlatform>()
            where TPlatform : IDatabasePlatform,new()
        {
            this._platform = new TPlatform();
            return this;
        }

        public NHibernateConfiguration RegisterLinqExtension(object extension)
        {
            
            var item = extension as ILinqToHqlGeneratorsRegistry;
            if (item != null)
            {
                this._linqExtension = item;
            }
            return this;
        }

        public virtual IRepositoryConfiguration Start()
        {
            this._sessionFactoryBuilder = new SessionFactoryBuilder(this._platform, this._connectionString, this._assemblies, this._updateSchema, this._defaultSchema, this._linqExtension, this._showSql, _exposedConfiguration);
            return this;
        }

        public IDataAccessor<T> Create<T>()
        {
            return Create<T>(DefaultConnection);
        }

        private IBeforeAddListener _listener;
        public IRepositoryConfiguration WithBeforeAddListener(IBeforeAddListener listener)
        {
            this._listener = listener;
            return this;
        }

        public virtual IDataAccessor<T> Create<T>(string name)
        {
            return new NHibernateDataAccessor<T>(new SessionBuilder(_sessionFactoryBuilder));
        } 
    }
}
