using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI.nRepo.Configuration;

namespace AI.nRepo.Sharding
{
    public interface IShardingStrategy
    {
        object DataAccessor { get; }
        bool Handles(object obj);
    }

    public abstract class ShardingStrategyBase<T> : IShardingStrategy
        where T : class
    {
        
        private readonly IDataAccessor<T> _accessor;
        public ShardingStrategyBase(IDataAccessor<T> accessor)
        {
            this._accessor = accessor;
        }

        public object DataAccessor
        {
            get
            {
                return _accessor;
            }
        }


        public abstract bool Handles(T obj);


        public bool Handles(object obj)
        {
            var t = obj as T;
            if (t == null)
                return false;
            return Handles(t);
        }

        
    }
}
