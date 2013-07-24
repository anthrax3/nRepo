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
        
        public static void ShardBy<T,TKey>(this ClassMap<T> classMap, Func<T,string> rule, Func<TKey, string> keyRule)
            where T : class
        {
            ShardLocator.RegisterShardRule<T,TKey>(rule,keyRule);
        }

       
    }
}
