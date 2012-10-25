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

        public void Start()
        {
            
        }

        public RavenDbConfiguration ConnectionString(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }


        public IDataAccessor<T> Create<T>()
        {
            return new RavenDbDataAccessor<T>();
        }
    }
}
