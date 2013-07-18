using AI.nRepo.Configuration;
using AI.nRepo.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo
{
    public static class ConfigurationExtensions
    {
        public static EntityFrameworkConfiguration EntityFramework(this IRepositorySelector selector)
        {
            return new EntityFrameworkConfiguration();
        }
    }
}
