using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Sharding.Configuration
{
    /// <summary>
    /// Responsible for managing all shard mappings, strategies, and locators
    /// </summary>
    public class ShardManager
    {
        private static ShardManager _instance = new ShardManager();
        private Dictionary<Type, IShardingStrategy> _strategies = new Dictionary<Type,IShardingStrategy>();
        private Dictionary<Type, IShardLocator> _locators = new Dictionary<Type,IShardLocator>();

        private ShardManager()
        {

        }

        public static ShardManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public void RegisterLocator<T>(IShardLocator locator)
        {
            _locators[typeof(T)] = locator;
        }

        public void RegisterStrategy<T>(IShardingStrategy strategy)
        {
            _strategies[typeof(T)] = strategy;
        }

        public IShardingStrategy GetStrategy<T>()
        {
            return this.GetStrategy(typeof(T));
        }

        public IShardingStrategy GetStrategy(Type t)
        {
            if (_strategies.ContainsKey(t))
                return _strategies[t];
            return null;
        }

        public IShardLocator GetLocator(Type t)
        {
            if (_locators.ContainsKey(t))
                return _locators[t];
            return null;
        }

        public IShardLocator GetLocator<T>()
        {
            return this.GetLocator(typeof(T));
        }


    }
}
