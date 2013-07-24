using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Sharding
{
    /// <summary>
    /// Responsible for determining a shard, given a full object to persist, remove, or edit
    /// </summary>
    public interface IShardingStrategy
    {
        string SelectShard<T>(T entity);

    }
}
