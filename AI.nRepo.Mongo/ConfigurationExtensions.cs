using AI.nRepo.Configuration;
using AI.nRepo.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo
{
    public static class ConfigurationExtensions
    {
        public static MongoDbConfiguration MongoDB(this IRepositorySelector selector)
        {
            return new MongoDbConfiguration();
        }
    }
}
