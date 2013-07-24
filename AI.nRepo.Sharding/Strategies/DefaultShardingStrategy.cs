using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Sharding.Strategies
{
    public class DefaultShardingStrategy<T> : IShardingStrategy
    {
        private Func<T, string> _function;
        public DefaultShardingStrategy(Func<T,string> function)
        {
            _function = function;
        }

        public string SelectShard<U>(U entity)
        {
            //TODO: hacky thunk here
            var e = (T)(object)entity;
            return _function(e);
        }
    }
}
