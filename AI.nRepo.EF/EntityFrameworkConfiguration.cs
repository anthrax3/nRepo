using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AI.nRepo.EntityFramework
{
    public class EntityFrameworkConfiguration : IRepositoryConfiguration
    {
        private const string DefaultConnection = "Default";
        private string _connectionString;
        private IList<IConfigureATypeForPersistence> _configurations = new List<IConfigureATypeForPersistence>();

        public EntityFrameworkConfiguration ConnectionString(string connectionString)
        {
            _connectionString = connectionString;
            return this;
        }

        public EntityFrameworkConfiguration AddConfiguration<T>()
            where T : IConfigureATypeForPersistence, new()
        {
            this._configurations.Add(new T());
            return this;
        } 

        public IRepositoryConfiguration Start()
        {
            return this;
        }

        public IDataAccessor<T> Create<T>()
            where T : class
        {
            return new EntityFrameworkDataAccessor<T>(_connectionString, _configurations);
        }
    }
}
