using AI.nRepo.Configuration;
using AI.nRepo.Couch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo
{
    public static class ConfigurationExtensions
    {
        public static CouchDbConfiguration CouchDb(this IRepositorySelector selector)
        {
            return new CouchDbConfiguration();
        }
    }
}
