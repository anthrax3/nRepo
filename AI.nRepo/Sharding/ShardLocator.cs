using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.Sharding
{
    public static class ShardLocator
    {
        private static Dictionary<Type, IShardStrategy> _rules;
        public static void RegisterShardRule<T,TKey>(Func<T, string> rule, Func<TKey,string> keyRule)
            where T : class
            where TKey : class
        {
            _rules[typeof(T)] = new FunctionBasedShardStrategy<T,TKey>(rule, keyRule);
        }

        public static string GetShard<T>(T obj)
        {
            if (!_rules.ContainsKey(typeof(T)))
                return null;
            return _rules[typeof(T)].GetShard(obj);
        }

        public static string GetShardByKey<T>(object key)
        {
            if (!_rules.ContainsKey(typeof(T)))
                return null;
            return _rules[typeof(T)].GetShardByKey(key);
        }
    }
}
