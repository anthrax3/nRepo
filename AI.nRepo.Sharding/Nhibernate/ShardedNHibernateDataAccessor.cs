using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.nRepo.Configuration;
using AI.nRepo.NHibernate;
using AI.nRepo.Sharding.Configuration;

namespace AI.nRepo.Sharding.Nhibernate
{
    public class ShardedNHibernateDataAccessor<T> : IDataAccessor<T>
    {
        private Dictionary<string, NHibernateDataAccessor<T>> _configurations;
        public ShardedNHibernateDataAccessor(Dictionary<string, dynamic> dataAccessors)
        {
            _configurations = new Dictionary<string, NHibernateDataAccessor<T>>();
            foreach (var kvp in dataAccessors)
            {
                _configurations[kvp.Key] = (NHibernateDataAccessor<T>)kvp.Value;
            }
        }

      

        protected NHibernateDataAccessor<T> GetShard(T entity)
        {
            var strategy = ShardManager.Instance.GetStrategy<T>();
            var alias = strategy.SelectShard(entity);
            return _configurations[alias];
        }

        protected NHibernateDataAccessor<T> GetDefaultShard()
        {
            
            if (_configurations.Count == 0)
                return null;
            return _configurations.First().Value;
        }

        protected NHibernateDataAccessor<T> LocateShard(object key)
        {
            var locator = ShardManager.Instance.GetLocator<T>();
            var alias = locator.LocateShard(key);
            if (alias == null)
                return GetDefaultShard();
            return _configurations[alias];
        }

        protected IEnumerable<NHibernateDataAccessor<T>> GetAllShards()
        {
            var locator = ShardManager.Instance.GetLocator<T>();
            var shardAliaii = locator.GetAllShards<T>();
            foreach (var alias in shardAliaii)
            {
                yield return _configurations[alias];
            }
        }

        public void Add(T entity)
        {
            var shard = GetShard(entity);
            shard.BeginTransaction();
            shard.Add(entity);
            shard.CommitTransaction();
        }

        public void Remove(T entity)
        {
            var shard = GetShard(entity);
            shard.BeginTransaction();
            shard.Remove(entity);
            shard.CommitTransaction();
        }

        public void Remove(IList<T> entities)
        {
            foreach (var entity in entities)
                this.Remove(entity);
        }

        public T Get(object key)
        {
            var shard = LocateShard(key);
            return shard.Get(key);
        }

        public IList<T> GetAll()
        {
            var shard = GetDefaultShard();
            return shard.GetAll();
        }

        public IList<T> GetAll(int pageSize, int pageNumber)
        {
            var shard = this.GetDefaultShard();
            return shard.GetAll(pageSize, pageNumber);
        }

        public void BeginTransaction()
        {
           
        }

        public void CommitTransaction()
        {
            
        }

        public void RollbackTransaction()
        {
            
        }

        public void Add(IList<T> entities)
        {
            foreach (var entity in entities)
                this.Add(entity);
        }

        public IQueryable<T> CreateQuery()
        {
            var shard = this.GetDefaultShard();
            return shard.CreateQuery();
        }

        public IList<T> ExecuteQuery(string query)
        {
            var shard = this.GetDefaultShard();
            return shard.ExecuteQuery(query);
        }

        public void Dispose()
        {
            foreach (var config in this._configurations)
                config.Value.Dispose();
        }
    }
}
