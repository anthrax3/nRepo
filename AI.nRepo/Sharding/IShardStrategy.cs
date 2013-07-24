using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.Sharding
{
    public interface IShardStrategy
    {
        string GetShard(object obj);

        string GetShardByKey(object obj);
    }
}
