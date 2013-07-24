using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.nRepo.Configuration;
using AI.nRepo.Sharding.Nhibernate;

namespace AI.nRepo
{
    public static class ConfigureExtensions
    {
        public static ShardedNhibernateConfiguration ShardedNHibernate(this IRepositorySelector selector)
        {
            return new ShardedNhibernateConfiguration();
        }
    }
}
