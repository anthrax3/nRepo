using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using AI.nRepo.DbPlatforms;
using NHibernate;

namespace AI.nRepo.Configuration
{
    public class NHibernateConfiguration : IRepositoryConfiguration
    {
        private readonly IList<Assembly> _assemblies;
        private bool _updateSchema;
        private Dictionary<string,string> _connectionStrings;
        private IDatabasePlatform _platform;
        private object _interceptor;
        private Dictionary<string,SessionFactoryBuilder> _sessionFactoryBuilders;
        private string _defaultSchema = "dbo";
        private const string DefaultConnection = "Default";
        
        public NHibernateConfiguration()
        {
            _assemblies = new List<Assembly>();
            this._platform = new MsSqlServer.Server2012Platform();
            this._connectionStrings = new Dictionary<string, string>();
            this._sessionFactoryBuilders = new Dictionary<string, SessionFactoryBuilder>();
        }

        public NHibernateConfiguration AddMappings(Assembly assembly)
        {
            this._assemblies.Add(assembly);
            return this;
        }

        public NHibernateConfiguration SetInterceptor(object interceptor)
        {
            this._interceptor = interceptor;
            return this;
        }


        public NHibernateConfiguration ConnectionString(string connectionString)
        {
            return RegisterConnection(connectionString, DefaultConnection);
        }

        public NHibernateConfiguration RegisterConnection(string connectionName, string connectionString)
        {
            _connectionStrings[connectionName] = connectionString;
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

        public IRepositoryConfiguration Start()
        {
            if(!_connectionStrings.Any())
                throw new InvalidOperationException("No connections are registered with nRepo");
            foreach(var connection in this._connectionStrings)
            {
                _sessionFactoryBuilders[connection.Key] = new SessionFactoryBuilder(this._platform, connection.Value, this._assemblies, this._updateSchema, this._interceptor, this._defaultSchema);
            }
            
            return this;
        }

        public IDataAccessor<T> Create<T>()

        {
            return Create<T>(DefaultConnection);
        }

        public IDataAccessor<T> Create<T>(string name)
        {
            //TODO: use IoC.  This will be interesting b/c we will want to allow for the fluent interface to specify which builder to use
            if (!_sessionFactoryBuilders.Any())
                throw new InvalidOperationException("You must first start the repository configuration before attempting to access data");
            if(!this._sessionFactoryBuilders.ContainsKey(name))
                throw new InvalidOperationException("nRepo cannot locate a registered connection with name " + name);
            var theOne = this._sessionFactoryBuilders[name];
            return new NHibernateDataAccessor<T>(new SessionBuilder(theOne));
        } 
    }
}
