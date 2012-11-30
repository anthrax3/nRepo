using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.EF
{
    public class EntityFrameworkConfiguration : IRepositoryConfiguration
    {
        private string _connectionString;

        public EntityFrameworkConfiguration ConnectionString(string connectionString)
        {
            this._connectionString = connectionString;
            return this;
        }

        public IRepositoryConfiguration Start()
        {
            return this;
        }



        public IDataAccessor<T> Create<T>()
        {
            
            return new EntityFrameworkDataAccessor<T>(_connectionString);
        }
    }
}
