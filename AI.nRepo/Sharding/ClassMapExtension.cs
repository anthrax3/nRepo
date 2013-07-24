using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AI.nRepo.Sharding
{
    public static class ClassMapExtension
    {
        
        public static void ShardBy<T>(this ClassMap<T> classMap, Func<T,string> func)
            where T : class
        {
            ShardLocator.RegisterShardRule<T>(func);
        }
    }
}
