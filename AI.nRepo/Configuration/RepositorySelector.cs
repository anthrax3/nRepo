using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Configuration
{
    public class RepositorySelector : IRepositorySelector
    {


        public IRepositoryConfiguration CouchDb()
        {
            throw new NotImplementedException();
        }

        public IRepositoryConfiguration EntityFramework()
        {
            throw new NotImplementedException();
        }

        public IRepositoryConfiguration NHibernate()
        {
            throw new NotImplementedException();
        }

        public IRepositoryConfiguration RavenDb()
        {
            throw new NotImplementedException();
        }

        public IRepositoryConfiguration MongoDB()
        {
            throw new NotImplementedException();
        }
    }
}
