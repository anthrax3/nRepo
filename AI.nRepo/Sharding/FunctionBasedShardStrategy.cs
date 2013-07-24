using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.Sharding
{
    public class FunctionBasedShardStrategy<T> : IShardStrategy
        where T : class
    {
        private readonly Func<T, string> _function;
        public FunctionBasedShardStrategy(Func<T, string> func)
        {
            _function = func;
        }



        public string GetShard(object obj)
        {
            return _function(obj as T);
        }
    }
}
