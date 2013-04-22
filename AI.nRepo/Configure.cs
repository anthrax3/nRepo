using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AI.nRepo
{
    public static class Configure
    {
        static Configure()
        {
            RepositorySelector = new RepositorySelector();
        }

        private static readonly IRepositorySelector RepositorySelector;

        public static IRepositorySelector As
        {
            get
            {
                return RepositorySelector;
            }
        }
    }
}
