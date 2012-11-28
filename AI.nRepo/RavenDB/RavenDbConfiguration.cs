using AI.nRepo.RavenDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Configuration
{
    public class RavenDbConfiguration : IRepositoryConfiguration
    {
        private string _connectionString;

        public IRepositoryConfiguration Start()
        {
            return this;
        }

        public RavenDbConfiguration ConnectionString(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }


        public IDataAccessor<T> Create<T>()
        {
            var session = new RavenDbSessionBuilder(this._connectionString);
            return new RavenDbDataAccessor<T>(session.Session);
            
        }
    }
}
