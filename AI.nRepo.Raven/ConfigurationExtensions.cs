using AI.nRepo.Configuration;
using AI.nRepo.Raven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo
{
    public static class ConfigurationExtensions
    {
        public static RavenDbConfiguration RavenDb(this IRepositorySelector selector)
        {
            return new RavenDbConfiguration();
        }
    }
}
