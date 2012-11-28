using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using AI.nRepo.DbPlatforms;

namespace AI.nRepo.Configuration
{
    public class NHibernateConfiguration : IRepositoryConfiguration
    {
        private readonly IList<Assembly> _assemblies;
        private bool _updateSchema;
        private string _connectionString;
        private IDatabasePlatform _platform;
        private SessionFactoryBuilder _sessionFactoryBuilder;
        
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

        public NHibernateConfiguration Platform<TPlatform>()
            where TPlatform : IDatabasePlatform,new()
        {
            this._platform = new TPlatform();
            return this;
        }

        public IRepositoryConfiguration Start()
        {
            if(_sessionFactoryBuilder == null)
            _sessionFactoryBuilder = new SessionFactoryBuilder(this._platform, this._connectionString, this._assemblies, this._updateSchema);
            return this;
        }

        public IDataAccessor<T> Create<T>()
        {
            //TODO: use IoC.  This will be interesting b/c we will want to allow for the fluent interface to specify which builder to use
            if (_sessionFactoryBuilder == null)
                throw new InvalidOperationException("You Must first start the repository configuration before attempting to access data");
            return new NHibernateDataAccessor<T>(new SessionBuilder(_sessionFactoryBuilder));
        }
    }
}
