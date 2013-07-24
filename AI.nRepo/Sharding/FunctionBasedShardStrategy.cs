using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.Sharding
{
    public class FunctionBasedShardStrategy<T, TKey> : IShardStrategy
        where T : class
        where TKey : class
    {
        private readonly Func<T, string> _rule;
        private readonly Func<TKey, string> _keyRule;
        public FunctionBasedShardStrategy(Func<T, string> func, Func<TKey, string> keyRule)
        {
            _rule = func;
            _keyRule = keyRule;
        }



        public string GetShard(object obj)
        {
            return _rule(obj as T);
        }


        public string GetShardByKey(object obj)
        {
            return _keyRule(obj as TKey);
        }
    }
}
