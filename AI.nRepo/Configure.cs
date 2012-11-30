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
            _repositorySelector = new RepositorySelector();
        }

        private static IRepositorySelector _repositorySelector;

        public static IRepositorySelector As
        {
            get
            {
                return _repositorySelector;
            }
        }
    }
}
