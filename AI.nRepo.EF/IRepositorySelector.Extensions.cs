using AI.nRepo.Configuration;
using AI.nRepo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo
{
    public static class RepositorySelectorExtensions
    {
        public static EntityFrameworkConfiguration EntityFramework(this IRepositorySelector selector)
        {
            return new EntityFrameworkConfiguration();
        }
    }
}
