using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Configuration
{
    public class NHibernateConfiguration : IRepositoryConfiguration
    {
        private readonly IList<Assembly> _assemblies;
        private bool _updateSchema;
        private string _connectionString;

        
        public NHibernateConfiguration()
        {
            _assemblies = new List<Assembly>();
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

        public void Start()
        {
            new SessionFactoryBuilder(this._connectionString, this._assemblies, this._updateSchema);
        }
    }
}
