using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo.Configuration
{
    public interface IRepositorySelector
    {
        IRepositoryConfiguration CouchDb();

        IRepositoryConfiguration EntityFramework();

        NHibernateConfiguration NHibernate();

        IRepositoryConfiguration RavenDb();

        IRepositoryConfiguration MongoDB();

       
    }
}
