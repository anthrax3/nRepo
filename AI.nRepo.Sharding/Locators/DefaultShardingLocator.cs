using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Sharding.Locators
{
    public class DefaultShardingLocator<T> : IShardLocator
    {
        private Func<T, string> _function;
        private IList<string> _shards;
        public DefaultShardingLocator(Func<T, string> function)
        {
            _function = function;
        }

        public string LocateShard<T>(T entity)
        {
            return this.LocateShard(typeof(T), entity);
        }

       

        public string LocateShard(Type t, Object entity)
        {
            if (_function != null)
                return _function((T)entity);
            return null;
        }

        public IList<string> GetAllShards<T>()
        {
            return this.GetAllShards(typeof(T));
        }

        public IList<string> GetAllShards(Type t)
        {
            return this._shards;
        }


        public void AvailableShards(params string[] shards)
        {
            _shards = shards.ToArray();
        }
    }
}
