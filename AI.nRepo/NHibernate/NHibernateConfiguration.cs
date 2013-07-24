using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AI.nRepo.Configuration;
using AI.nRepo.DbPlatforms;

namespace AI.nRepo.NHibernate
{
    public class NHibernateConfiguration : IRepositoryConfiguration
    {
        private readonly IList<Assembly> _assemblies;
        private bool _updateSchema;
        private IDatabasePlatform _platform;
        private string _defaultSchema = "dbo";
        private const string DefaultConnection = "Default";
        private string _connectionString;
        protected SessionFactoryBuilder _sessionFactoryBuilder;

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

        public NHibernateConfiguration UpdateSchemaOnDebug()
        {
            _updateSchema = true;
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

        public virtual IRepositoryConfiguration Start()
        {
            this._sessionFactoryBuilder = new SessionFactoryBuilder(this._platform, this._connectionString, this._assemblies, this._updateSchema, this._defaultSchema);
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
