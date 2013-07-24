using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.Sharding
{
    public static class ShardLocator
    {
        private static Dictionary<Type, IShardStrategy> _rules;
        public static void RegisterShardRule<T>(Func<T, string> func)
            where T : class
        {
            _rules[typeof(T)] = new FunctionBasedShardStrategy<T>(func);
        }

        public static string GetShard<T>(T obj)
        {
            if (!_rules.ContainsKey(typeof(T)))
                return null;
            return _rules[typeof(T)].GetShard(obj);
        }
    }
}
