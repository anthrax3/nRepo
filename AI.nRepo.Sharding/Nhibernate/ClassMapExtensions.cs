using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AI.nRepo.Sharding.Configuration;
using AI.nRepo.Sharding.Locators;
using AI.nRepo.Sharding.Strategies;
using FluentNHibernate.Mapping;

namespace AI.nRepo.Sharding
{
    public static class ClassMapExtensions
    {
        public static void ShardingStrategy<T>(this ClassMap<T> map, Func<T,string> function)
        {
            //var function = expr.Compile();
            ShardManager.Instance.RegisterStrategy<T>(new DefaultShardingStrategy<T>(function));
        }

        public static IShardLocator ShardingLocator<T>(this ClassMap<T> map, Func<T, string> function)
        {
            var locator = new DefaultShardingLocator<T>(function);
            ShardManager.Instance.RegisterLocator<T>(locator);
            return locator;
        }

        public static IShardLocator ShardingLocator<T>(this ClassMap<T> map)
        {
            var locator = new DefaultShardingLocator<T>(null);
            ShardManager.Instance.RegisterLocator<T>(locator);
            return locator;
        }
    }
}
