using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.nRepo.Configuration;
using AI.nRepo.NHibernate;

namespace AI.nRepo.Sharding.Nhibernate
{
    public class ShardedNhibernateConfiguration : IRepositoryConfiguration
    {
        private Dictionary<string,NHibernateConfiguration> _configurations = new Dictionary<string,NHibernateConfiguration>();
       
        public ShardedNhibernateConfiguration()
        {

        }

        public NHibernateConfiguration CreateShard(string alias)
        {
            var configuration = new NHibernateConfiguration();
            _configurations[alias] = configuration;
            return configuration;
        }

        public IRepositoryConfiguration Start()
        {
            foreach (var config in this._configurations)
                config.Value.Start();
            return this;
        }

        public IDataAccessor<T> Create<T>()
            where T: class
        {
            var list = new Dictionary<string, dynamic>();
            foreach (var kvp in this._configurations)
            {
                list[kvp.Key] = kvp.Value.Create<T>();
                
            }
            return new ShardedNHibernateDataAccessor<T>(list);
        }


        public IUnitOfWork GetCurrentUnitOfWork()
        {
            throw new NotImplementedException();
        }

        public void CloseUnitOfWork()
        {
            throw new NotImplementedException();
        }
    }
}
