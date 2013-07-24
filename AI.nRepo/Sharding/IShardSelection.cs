using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo.Sharding
{
    public interface IShardSelection : IDisposable
    {
        string Shard { get; }
    }

    public class ShardSelection : IShardSelection
    {
        public ShardSelection(string alias)
        {
            this.Shard = alias;
        }

        public string Shard
        {
            get;
            private set;
        }

        public void Dispose()
        {
            
        }
    }
}
