using AI.nRepo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AI.nRepo
{
    public class Configure
    {
        static Configure()
        {
            RepositorySelector = new RepositorySelector();
            _masterConfiguration = new nRepoConfiguration();
        }
        private static readonly InRepoConfiguration _masterConfiguration;
        private static readonly IRepositorySelector RepositorySelector;

        public static InRepoConfiguration MasterConfiguration
        {
            get
            {
                return _masterConfiguration;
            }
        }

        public static IRepositorySelector As
        {
            get
            {
                return RepositorySelector;
            }
        }

        public static InRepoConfiguration With(string alias, IRepositoryConfiguration configuration)
        {
            return MasterConfiguration.With(alias, configuration);
        }

        
       

        
    }
}
