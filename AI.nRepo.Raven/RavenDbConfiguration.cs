
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI.nRepo.Configuration;

namespace AI.nRepo.Raven
{
    public class RavenDbConfiguration : IRepositoryConfiguration
    {
        private string _connectionString;
        private string _databaseName;

        public IRepositoryConfiguration Start()
        {
            return this;
        }

        public RavenDbConfiguration ConnectionString(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }

        public RavenDbConfiguration DatabaseName(string databaseName)
        {
            _databaseName = databaseName;
            return this;
        }

        public IDataAccessor<T> Create<T>()
        {
            var session = new RavenDbSessionBuilder(this._connectionString, this._databaseName);
            return new RavenDbDataAccessor<T>(session.Session);
        }
    }
}
