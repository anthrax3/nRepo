using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI.nRepo.Configuration;

namespace AI.nRepo.Sharding
{
    public static class ShardRegistry
    {
        private static Dictionary<Type, IList<IShardingStrategy>> _shards = new Dictionary<Type, IList<IShardingStrategy>>();

        private static void EnsureExists(Type t)
        {
            if (!_shards.ContainsKey(t))
            {
                _shards[t] = new List<IShardingStrategy>();
            }
        }

        private static Type GetTypeForShardingStrategy<T>(ShardingStrategyBase<T> shardStrategy)
            where T : class
        {
            return typeof(T);
        }


        public static void Register<T>(ShardingStrategyBase<T> shardStrategy)
            where T : class
        {
            EnsureExists(GetTypeForShardingStrategy(shardStrategy));
            _shards[GetTypeForShardingStrategy(shardStrategy)].Add(shardStrategy);
        }

        public static IShardingStrategy GetShard<T>(T obj)
        {
            EnsureExists(typeof(T));
            var strategies = _shards[typeof(T)];
            foreach (var strategy in strategies)
            {
                if (strategy.Handles(obj))
                    return strategy;
            }
            return null;
        }
    }
}
