using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Sharding
{
    /// <summary>
    /// Responsible for locating a shard, in order to retrieve an object
    /// </summary>
    public interface IShardLocator
    {
        string LocateShard<T>(T entity);

        string LocateShard(Type t, object entity);

        IList<string> GetAllShards<T>();

        IList<string> GetAllShards(Type t);

        void AvailableShards(params string [] shards);


    }
}
