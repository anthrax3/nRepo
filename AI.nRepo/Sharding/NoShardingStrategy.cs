using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI.nRepo.Configuration;

namespace AI.nRepo.Sharding
{
    public class NoShardingStrategy<T> : ShardingStrategyBase<T>
        where T : class
    {
        public NoShardingStrategy(IDataAccessor<T> dataAccessor)
            :base(dataAccessor)
        {

        }
        public override bool Handles(T obj)
        {
            return true;
        }
    }
}
